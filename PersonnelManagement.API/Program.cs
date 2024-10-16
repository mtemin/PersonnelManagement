using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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

//EF Core
builder.Services.AddDbContext<PersonnelManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PERSONNEL_MANAGEMENT")));
//Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<PersonnelManagementDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
});


//Repository
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IRepository<Employee>, EmployeeRepository>();    
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IRepository<Company>, CompanyRepository>();    
builder.Services.AddTransient<ICompanyService, CompanyService>();
//Automapper
builder.Services.AddAutoMapper(typeof(IStartup));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
