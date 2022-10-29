using SSYS.API.Shared.Domain.Model;

namespace SSYS.API.IAM.Domain.Models;

public class UserRole : BaseModel
{
    public enum Role
    {
        Admin,
        User,
        Guest,
        Employee
    }
    public Role RoleName { get; set; }
}