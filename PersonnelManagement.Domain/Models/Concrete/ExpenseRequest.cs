using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using PersonnelManagement.Data.Model.Abstract;

namespace PersonnelManagement.Data.Model.Concrete;

public class ExpenseRequest:Request
{
    [Required]
    public decimal Amount { get; set; }
}