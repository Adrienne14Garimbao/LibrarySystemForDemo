using System.Threading.Tasks;
using Abp.Application.Services;
using LibrarySystemForDemo.Authorization.Accounts.Dto;

namespace LibrarySystemForDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
