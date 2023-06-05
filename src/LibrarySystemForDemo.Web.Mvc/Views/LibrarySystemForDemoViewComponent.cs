using Abp.AspNetCore.Mvc.ViewComponents;

namespace LibrarySystemForDemo.Web.Views
{
    public abstract class LibrarySystemForDemoViewComponent : AbpViewComponent
    {
        protected LibrarySystemForDemoViewComponent()
        {
            LocalizationSourceName = LibrarySystemForDemoConsts.LocalizationSourceName;
        }
    }
}
