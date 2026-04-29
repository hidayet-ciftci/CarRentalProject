using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });


//builder.Services.AddScoped<ICustomerService, CustomerManager>();
//builder.Services.AddScoped<IValidator<Customer>, CustomerValidator>();
//builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();


//builder.Services.AddSingleton<IVehicleService, VehicleManager>();
//builder.Services.AddSingleton<IVehicleDal, EfVehicelDal>();

//builder.Services.AddSingleton<IUserService, UserManager>();
//builder.Services.AddSingleton<IUserDal, EfUserDal>();

//builder.Services.AddSingleton<IServiceRecordService, ServiceRecordManager>();
//builder.Services.AddSingleton<IServiceRecordDal, EfServiceRecordDal>();

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();  // bu kullanici kim ?
app.UseAuthorization();   // bu kullanicinin bunu yapmaya yetkisi var mi ?


app.MapControllers();

app.Run();


// sıfırdan proje ++ 
// token , refresh token 
// role bazlı metod'a ulasma 
// erisim hakkın yok uyarısı 
// migration yok , elle girilecek ++
// veritabani check, unique constraint koyulacak ++ 
// microsoft kutuphanesi ile IoC ++
// join ile veri cekilecek , DTO ++
// fluent validation  ++
// N-tier arch ile projeyi kur +-


// sorulacak sorular : -> Hem check hem fluent_validation ikisi de mi kullanilir ?
// AOP eksiklikleri ? farklı mı kullanacağız ? 
// aynı araç state tamamlandi olmadan ekleme durumu best practice ? 
// simdilik backend'de kontrol ediliyor

// iş kurallari ++
// IoC ++
// crud ve business islemleri okey olsun. proje check et sonra auth'a gec ++
// Auth ++
// check constraint ve veriler elle girilecek. ++