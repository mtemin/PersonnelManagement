namespace PersonnelManagement.API.DTO;

    public class UpdateEmployeeDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public int CompanyId { get; set; }
    }