using System.Collections.Generic;
using LibrarySystemForDemo.Roles.Dto;

namespace LibrarySystemForDemo.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
