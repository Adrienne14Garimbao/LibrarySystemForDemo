using Abp.Application.Services;
using LibrarySystemForDemo.MultiTenancy.Dto;

namespace LibrarySystemForDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

