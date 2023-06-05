using System.Collections.Generic;
using LibrarySystemForDemo.Roles.Dto;

namespace LibrarySystemForDemo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
