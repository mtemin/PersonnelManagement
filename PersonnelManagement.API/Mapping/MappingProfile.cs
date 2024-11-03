using AutoMapper;
using PersonnelManagement.API.DTO;
using PersonnelManagement.Domain.Models.Abstract;
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
    
    CreateMap<LeaveDayDTO,LeaveDay >()
        .ReverseMap();
        
    CreateMap<ExpenseDTO,Expense >()
        .ReverseMap();
        
    CreateMap<EducationDTO,Education >()
        .ReverseMap();
        
    CreateMap<CertificateDTO,Certificate >()
        .ReverseMap();
        
    CreateMap<ProfessionalExperienceDTO,ProfessionalExperience >()
        .ReverseMap();


    CreateMap<UpdateEmployeeDTO, Employee>();
    CreateMap<UpdateCompanyDTO, Company>();
    CreateMap<UpdateLeaveDayDTO, LeaveDay>();
    CreateMap<UpdateExpenseDTO, Expense>();
    CreateMap<UpdateEducationDTO, Education>();
    CreateMap<UpdateCertificateDTO, Certificate>();
    CreateMap<UpdateProfessionalExperienceDTO, ProfessionalExperience>();
    
    }
}