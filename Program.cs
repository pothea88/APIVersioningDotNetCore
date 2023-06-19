using Microsoft.EntityFrameworkCore.SqlServer;
using ApiVersioning.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ApiVersioning.Services;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using ApiVersioning.DAL;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = ("'v'VVV");
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddDbContext<CountryDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("ApiVersioning"));
});
builder.Services.AddScoped<ICountryService, CountryService>();
var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach(var item in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"{item.GroupName}/swagger.json", item.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

