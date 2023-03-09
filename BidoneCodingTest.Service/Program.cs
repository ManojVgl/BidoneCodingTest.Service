
using BidoneCodingTest.Domain.Appsettings;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
//Read Configuration from appSettings    
AppSettings settings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
//Read Configuration from appSettings    
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

//Initialize Logger    
var logger = new LoggerConfiguration().
    ReadFrom.Configuration(config)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyAllowSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
