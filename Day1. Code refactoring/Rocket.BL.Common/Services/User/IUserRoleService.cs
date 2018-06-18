namespace Rocket.BL.Common.Services.User
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;

    using Rocket.BL.Common.Models.UserRoles;

    public interface IUserRoleService
    {
        Task<IdentityResult> Delete(string roleId);
        IEnumerable<Role> GetAllRoles();
        Task<Role> GetById(string roleId);
        Task<IdentityResult> Insert(Role role);
        Task<bool> RoleIsExists(string filter);
        Task<IdentityResult> Update(string roleId, string roleName);
    }
}