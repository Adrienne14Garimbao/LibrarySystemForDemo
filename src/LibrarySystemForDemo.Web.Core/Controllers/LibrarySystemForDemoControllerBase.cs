using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LibrarySystemForDemo.Controllers
{
    public abstract class LibrarySystemForDemoControllerBase: AbpController
    {
        protected LibrarySystemForDemoControllerBase()
        {
            LocalizationSourceName = LibrarySystemForDemoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
