using System.Collections.Generic;
using LibrarySystemForDemo.Roles.Dto;

namespace LibrarySystemForDemo.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}