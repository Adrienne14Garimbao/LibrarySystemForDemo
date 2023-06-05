using Abp.AutoMapper;
using LibrarySystemForDemo.Sessions.Dto;

namespace LibrarySystemForDemo.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
