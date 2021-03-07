using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarManager>().SingleInstance();
            builder.RegisterType<BrandManager>().As<IBrandManager>().SingleInstance();
            builder.RegisterType<ColorManager>().As<IColorManager>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserManager>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerManager>().SingleInstance();
            builder.RegisterType<RentalManager>().As<IRentalManager>().SingleInstance();
            builder.RegisterType<CarImageManager>().As<ICarImageManager>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthManager>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();



            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                   .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                   {
                       Selector = new AspectInterceptorSelector()
                   }).SingleInstance();

        }
    }
}
