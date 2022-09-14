using AppServices.Validator;
using FluentValidation.AspNetCore;
using DomainServices.BaseServices;
using FluentValidation;
using DomainModel.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidation(config =>
{config.RegisterValidatorsFromAssemblyContaining<CustomerValidator>();});
builder.Services.AddSingleton<IBaseServices, BaseServices>();
builder.Services.AddScoped<IValidator<CustomersModel>, CustomerValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
