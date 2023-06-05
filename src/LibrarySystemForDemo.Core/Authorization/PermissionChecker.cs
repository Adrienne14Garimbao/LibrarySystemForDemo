using Abp.Authorization;
using LibrarySystemForDemo.Authorization.Roles;
using LibrarySystemForDemo.Authorization.Users;

namespace LibrarySystemForDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
