using System.Threading.Tasks;

namespace PersonnelManagement.Domain
{
    public interface IRoleSeeder
    {
        Task SeedRoles();
    }
}