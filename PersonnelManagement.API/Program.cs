using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PersonnelManagement.Data;
using PersonnelManagement.Domain;
using PersonnelManagement.Services;
using PersonnelManagement.Domain.Services;
using PersonnelManagement.Data.Repositories;
using PersonnelManagement.Domain.Repositories;
using PersonnelManagement.Domain.Models.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PersonnelManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PERSONNEL_MANAGEMENT")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IRepository<Employee>, EmployeeRepository>();    
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddAutoMapper(typeof(IStartup));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
