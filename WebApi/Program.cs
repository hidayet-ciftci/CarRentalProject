using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using WebAPI.Extensions;

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

//app.UseCustomMiddlewares();
app.UseSwaggerWithUI();
app.UseHttpsRedirection();
//app.UseSerilogRequestLogging();
//app.UseHangfireJobs();
app.UseAuthentication(); // bu kullanici kim ?
app.UseAuthorization();  // bu kullanicinin bunu yapmaya yetkisi var mi ?
app.MapControllers();

app.Run();