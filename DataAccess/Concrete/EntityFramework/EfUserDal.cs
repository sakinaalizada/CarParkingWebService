using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EFEntityRepositoryBase<User, CarParkingContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CarParkingContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaims in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaims.OperationClaimId
                             where userOperationClaims.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
        }
    }
}
