using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Domain.Models.Abstract;

namespace PersonnelManagement.Domain.Models.Concrete;

public class Certificate : Experience
{
    [Required]
    public int CertificateId { get; set; }
    [Required]
    public string CertificateName { get; set; }
    [Required]
    public string IssuingOrganization { get; set; }
    [Required]
    public string TotalHours { get; set; }
}