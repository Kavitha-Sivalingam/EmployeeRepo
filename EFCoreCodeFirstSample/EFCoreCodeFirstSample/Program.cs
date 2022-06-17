using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.DataManager;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmployeeContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("myConn")));

builder.Services.AddScoped<IDataRepository<Employee>, EmployeeManager>();

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
