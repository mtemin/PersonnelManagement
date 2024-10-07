using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Domain.Models.Abstract;

namespace PersonnelManagement.Domain.Models.Concrete;

public class LeaveRequest:Request
{
    [Required]
    public DateOnly LeaveStartDay { get; set; }
    [Required]
    public DateOnly LeaveEndDay { get; set; }
}