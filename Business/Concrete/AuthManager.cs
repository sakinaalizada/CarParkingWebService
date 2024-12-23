﻿using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Security.Hashing;
using Core.Security.Jwt;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        public AuthManager(ITokenHelper tokenHelper, IUserService userService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Access token created successfully");
        }

        public IDataResult<User> Login(UserLoginDto userLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userLoginDto.Email);
            if (userToCheck.Data == null)
                return new ErrorDataResult<User>("User not found!");
            if (!HashingHelper.ConfirmPassHash
                (userLoginDto.Password, userToCheck.Data.PasswordHash,
                userToCheck.Data.PasswordSalt))
                return new ErrorDataResult<User>("Wrong password");
            return new SuccessDataResult<User>(userToCheck.Data, "Login succesfully");
        }

        public IDataResult<User> Register(UserRegisterDto userRegisterDto, string password)
        {
            UserExists(userRegisterDto.Email);
            HashingHelper.CreatePassHash
                 (password, out var passHash, out var passSalt);
            var user = new User
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Email = userRegisterDto.Email,
                PasswordHash = passHash,
                PasswordSalt = passSalt,
                Status = true
            };
            return new SuccessDataResult<User>(user, "Register successfully");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email) != null)
                return new ErrorResult("User already exists");
            return new SuccessResult();
        }
    }
}