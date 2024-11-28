using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.Domain.Models.Concrete;

public class Expense:ExpenseRequest
{
    [Key]
    public int ExpenseId { get; set; }
    //expense request'i tip olarak kullanmak kötü gözükeceği için bu sınıfı oluşturdum.
}