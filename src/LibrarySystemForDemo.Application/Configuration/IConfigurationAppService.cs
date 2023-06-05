using System.Threading.Tasks;
using LibrarySystemForDemo.Configuration.Dto;

namespace LibrarySystemForDemo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
