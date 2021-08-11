
using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.EntityFrameWork.Concrete;

namespace Business.IoC.Autofac
{
    public class AutofacBusinessModule :  Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EFCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<EFParkingSpaceDal>().As<IParkingSpaceDal>().SingleInstance();
            builder.RegisterType<EFEmployeeDal>().As<IEmployeeDal>().SingleInstance();

            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<ParkingSpaceManager>().As<IParkingSpaceService>().SingleInstance();
        }
    }
}
