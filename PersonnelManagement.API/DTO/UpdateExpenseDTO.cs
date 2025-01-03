﻿namespace PersonnelManagement.API.DTO;

public class UpdateExpenseDTO
{
    public int EmployeeId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsApproved { get; set; }
    public decimal Amount { get; set; }
}