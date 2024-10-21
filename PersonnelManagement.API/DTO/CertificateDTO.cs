namespace PersonnelManagement.API.DTO;

public class CertificateDTO
{
    public int CertificateId { get; set; }
    public string CertificateName { get; set; }
    public string IssuingOrganization { get; set; }
    public string TotalHours { get; set; }
}