using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Data.Model.Abstract;

namespace PersonnelManagement.Data.Model;

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