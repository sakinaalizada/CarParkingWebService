using Core.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>>GetAll(Expression<Func<Car, bool>> filter = null);
        IDataResult<List<Car>> SearchByCarPlate(string text);
    }
}