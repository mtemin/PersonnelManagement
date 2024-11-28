
using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Domain.Models.Abstract;

namespace PersonnelManagement.Domain.Models.Concrete;

public class LeaveDay:LeaveRequest
{
    [Key]
    public int LeaveDayId { get; set; }
    //leave request'i tip olarak kullanmak kötü gözükeceği için bu sınıfı oluşturdum.
}