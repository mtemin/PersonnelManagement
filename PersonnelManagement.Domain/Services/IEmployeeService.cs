﻿using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.Domain.Services;

public interface IEmployeeService:IService<Employee>
{
    Task<Employee> UpdateEntityAsync(Employee employeeToBeUpdated, Employee employee);
    // Task<Company> GetEmployeeByCompanyId(int id);
}