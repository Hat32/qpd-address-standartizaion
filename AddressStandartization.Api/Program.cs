using AddressStandartization.Api.Configuration;
using AddressStandartization.Api.Settings;
using AddressStandartization.Settings;


var builder = WebApplication.CreateBuilder(args);


var swaggerSettings = SettingsLoader.Load<SwaggerSettings>("SwaggerSettings");


// Add services to the container.
var services = builder.Services;

services.AddCors();
services.AddAppSwagger(swaggerSettings);
services.AddAppAutoMapper();

services.AddExceptionHandler<GlobalExceptionHandler>();

services.AddEndpointsApiExplorer();
services.AddControllers();
services.AddProblemDetails();

services.AddCleanClient(builder.Configuration);


// Configure the HTTP request pipeline
var app = builder.Build();

app.UseExceptionHandler();

app.UseHttpsRedirection(); 

app.UseRouting(); 


app.UseAppSwagger(); 

app.MapControllers(); 

app.Run();