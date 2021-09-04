using Business.Abstract;
using Business.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Caching;
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
    public class EmployeeManager : IEmployeeService
    {
        private IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;

        }
        [ValidationAspect(typeof(EmployeeValidator))]
        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult Add(Employee employee)
        {
            _employeeDal.Add(employee);
            return new SuccessResult();


        }
        [CacheRemoveAspect("IEmployeeService.Get")]

        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
            return new SuccessResult();

        }
        [CachingAspect]
        public IDataResult<List<Employee>> GetAll(Expression<Func<Employee, bool>> filter = null)
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(filter));
        }
        [CachingAspect]
        public IDataResult<Employee> GetById(int id)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(m => m.EmployeeId == id));
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult();

        }
    }
}