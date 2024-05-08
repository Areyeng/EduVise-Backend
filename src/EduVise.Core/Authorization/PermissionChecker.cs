using Abp.Authorization;
using EduVise.Authorization.Roles;
using EduVise.Authorization.Users;

namespace EduVise.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
