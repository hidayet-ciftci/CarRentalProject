using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.IoC;
using Core.Utilities.Security;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddScoped<ICustomerService, CustomerManager>();
            serviceCollection.AddScoped<IValidator<Customer>, CustomerValidator>();
            serviceCollection.AddScoped<ICustomerDal, EfCustomerDal>();
            // transiat her istekte yeni olusturulur
            // scoped da istekde olusturulur aynı instance paylastilir.

            serviceCollection.AddSingleton<IVehicleService, VehicleManager>();
            serviceCollection.AddSingleton<IVehicleDal, EfVehicelDal>();

            serviceCollection.AddSingleton<IUserService, UserManager>();
            serviceCollection.AddSingleton<IUserDal, EfUserDal>();

            serviceCollection.AddSingleton<IServiceRecordService, ServiceRecordManager>();
            serviceCollection.AddSingleton<IServiceRecordDal, EfServiceRecordDal>();

            serviceCollection.AddScoped<IAuthService, AuthManager>();
            serviceCollection.AddScoped<JwtHelper>();

        }
    }
}
