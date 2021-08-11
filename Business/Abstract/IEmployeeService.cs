using Core.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IResult Add(Employee employee);
        IResult Update(Employee employee);
        IResult Delete(Employee employee);
        IDataResult<List<Employee>> GetAll(Expression<Func<Employee, bool>> filter = null);
        IDataResult<Employee> GetById(int id);
    }
}
