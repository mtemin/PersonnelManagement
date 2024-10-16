﻿using AutoMapper;
using PersonnelManagement.API.DTO;
using PersonnelManagement.Domain.Models.Concrete;
namespace PersonnelManagement.API.Mapping;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
    CreateMap<Employee, EmployeeDTO>()
        .ReverseMap();
    
    CreateMap<CompanyDTO,Company >()
        .ReverseMap();


    CreateMap<UpdateEmployeeDTO, Employee>();
    CreateMap<UpdateCompanyDTO, Company>();
    
    }
}