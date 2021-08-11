using Core.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IParkingSpaceService
    {
        IResult Add(ParkingSpace parkingSpace);
        IResult Update(ParkingSpace parkingSpace);
        IResult Delete(ParkingSpace parkingSpace);
        IDataResult< List<ParkingSpace>> GetAll(Expression<Func<ParkingSpace, bool>> filter = null);
        IDataResult<decimal> GetChargeForHourById(int id);
        IDataResult< ParkingSpace> GetById(int id);
    }
}