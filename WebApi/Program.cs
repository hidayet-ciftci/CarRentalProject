using Business.Jobs;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using WebAPI.Extensions;
using WebAPI.Middlewares;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);
 
// Services
//builder.Host.AddSerilogLogging();
builder.Services.AddControllers();
builder.Services.AddSwagger();
builder.Services.AddJwtAuth(builder.Configuration);
//builder.Services.AddHangfireWithPostgre(builder.Configuration);
builder.Services.AddDependencyResolvers(new ICoreModule[] { new CoreModule() });

var app = builder.Build();

// Pipeline
app.UseCustomMiddlewares();
app.UseSwaggerWithUI();
app.UseHttpsRedirection();
//app.UseSerilogRequestLogging();
//app.UseHangfireJobs();
app.UseAuthentication(); // bu kullanici kim ?
app.UseAuthorization();  // bu kullanicinin bunu yapmaya yetkisi var mi ?
app.MapControllers();

app.Run();


// sıfırdan proje ++ 
// token , refresh token ++
// role bazlı metod'a ulasma ++
// erisim hakkın yok uyarısı ++
// migration yok , elle girilecek ++
// veritabani check, unique constraint koyulacak ++ 
// microsoft kutuphanesi ile IoC ++
// join ile veri cekilecek , DTO ++
// fluent validation  ++
// N-tier arch ile projeyi kur ++


// sorulacak sorular : -> Hem check hem fluent_validation ikisi de mi kullanilir ? -> evet check + check
// AOP eksiklikleri ? farklı mı kullanacağız ? -> cache ? transaction ? AOP farklı bir kullanım tarzı o kadar da sart degil
// aynı araç state tamamlandi olmadan ekleme durumu best practice ? -> backend daha pratik,

// iş kurallari ++
// IoC ++
// crud ve business islemleri okey olsun. proje check et sonra auth'a gec ++
// Auth ++
// check constraint ve veriler elle girilecek. ++

// Bittenler -------------------------------------

// Salt ++
// database View ++ -> Joinler için oluşmuş tablo'yu DTO kullanarak yansıtmak.
// cronjob ++ -> * * * * * metodu kullanarak server'a zamanlı iş yaptırma
// Hangfire ++ -> veya quartz.net cronJOB ASP.NET taraflı kullanmak
// trigger ++ -> SQL Server'a yaz ya da savechanges'i override et.
// ILogger -> private readonly ILogger<UrunController> _logger;
// Dependency Injection ile gelir -> UrunController tip 'Den ziyade nereden geldigini belirtmek için kullanilir.
// Task -> Asenkron yapılar için await ile birlikte kullanılır.
// Lock -> Multi-Thread işlemlerin birbirlerini engellemek , aynı anda tek bir işlemin gerçekleşmesini saglar.
// middleware  -> işlemler arası geçiş. Middleware = pipeline’daki işlem birimi
// pipeline ++ -> Projedeki Akış 
// MVC ++ -> MVC yapısı Model - View - Controller yapısı ile küçük projelerde işe yarayan
// direkt istek karşısında html dönen yapı

// rabbitMQ loglama sistemi - rebus , redis ,gencay
// CQRS - gencay

// cacheing , performance , transaction ? AOP ? gerekliliği ? 

// expo 