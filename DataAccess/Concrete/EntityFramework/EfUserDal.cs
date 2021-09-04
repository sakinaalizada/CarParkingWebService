
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EFEntityRepositoryBase<User, CarParkingContext>, IUserDal
    {
        //public List<OperationClaim> GetClaims(User user)
        //{
        //    using (var context = new CarParkingContext())
        //    {
        //        var result = from operationClaim in context.OperationClaims

        //    }
        //}
        public List<OperationClaim> GetClaims(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
