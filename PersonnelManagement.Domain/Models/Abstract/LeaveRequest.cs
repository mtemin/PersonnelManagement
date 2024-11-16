using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Domain.Models.Abstract;

namespace PersonnelManagement.Domain.Models.Abstract;

public class LeaveRequest:Request
{
    [Key]
    public int LeaveDayId { get; set; }
    public string Type { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
}