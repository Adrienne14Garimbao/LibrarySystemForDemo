using Abp.Application.Services.Dto;

namespace LibrarySystemForDemo.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

