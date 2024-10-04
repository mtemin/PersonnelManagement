using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Data.Model.Abstract;

namespace PersonnelManagement.Data.Model.Concrete;

public class LeaveRequest:Request
{
    [Required]
    public DateOnly LeaveStartDay { get; set; }
    [Required]
    public DateOnly LeaveEndDay { get; set; }
}