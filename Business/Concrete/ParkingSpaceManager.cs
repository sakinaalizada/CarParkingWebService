using Business.Abstract;
using Business.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.CrossCuttingConcerns.Validation;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ParkingSpaceManager : IParkingSpaceService
    {
        private IParkingSpaceDal _parkingSpaceDal;
        public ParkingSpaceManager(IParkingSpaceDal parkingSpaceDal)
        {
            _parkingSpaceDal = parkingSpaceDal;

        }
        [ValidationAspect(typeof(ParkingSpaceValidator))]
        public IResult Add(ParkingSpace parkingSpace)
        {
            _parkingSpaceDal.Add(parkingSpace);
            return new SuccessResult();


        }

        public IResult Delete(ParkingSpace parkingSpace)
        {
            _parkingSpaceDal.Delete(parkingSpace);
            return new SuccessResult();

        }

        public IDataResult< List<ParkingSpace>> GetAll()
        {
            return new SuccessDataResult<List<ParkingSpace>>(_parkingSpaceDal.GetAll());

        }

        public IDataResult<List<ParkingSpace>> GetAll(Expression<Func<ParkingSpace, bool>> filter = null)
        {
            return new SuccessDataResult<List<ParkingSpace>>(_parkingSpaceDal.GetAll(filter));
        }

        public IDataResult<ParkingSpace> GetById(int id)
        {
            return new SuccessDataResult<ParkingSpace>(_parkingSpaceDal.Get(m => m.ParkingSpaceId == id));
        }

        public IDataResult< decimal > GetChargeForHourById(int id)
        {
            return new SuccessDataResult<decimal>(_parkingSpaceDal.Get(m => m.ParkingSpaceId == id).ChargeForHour);
        }
        [ValidationAspect(typeof(ParkingSpaceValidator))]
        public IResult Update(ParkingSpace parkingSpace)
        {
            _parkingSpaceDal.Update(parkingSpace);
            return new SuccessResult();


        }
    }
}
