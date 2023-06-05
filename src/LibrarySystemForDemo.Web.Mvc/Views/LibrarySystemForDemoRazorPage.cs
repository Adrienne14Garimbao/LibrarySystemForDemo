using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace LibrarySystemForDemo.Web.Views
{
    public abstract class LibrarySystemForDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected LibrarySystemForDemoRazorPage()
        {
            LocalizationSourceName = LibrarySystemForDemoConsts.LocalizationSourceName;
        }
    }
}
