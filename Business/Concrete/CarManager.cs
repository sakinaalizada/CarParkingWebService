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
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult();


        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());

        }

        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(filter));
        }

        public IDataResult<List<Car>> SearchByCarPlate(string text)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(m => m.CarPlate.ToLower().Contains(text)));
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}