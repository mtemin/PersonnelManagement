using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Domain.Models.Abstract;

namespace PersonnelManagement.Domain.Models.Concrete;

public class ExpenseRequest:Request
{

    [Required]
    public decimal Amount { get; set; }
}