using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibrarySystemForDemo.Configuration;

namespace LibrarySystemForDemo.Web.Host.Startup
{
    [DependsOn(
       typeof(LibrarySystemForDemoWebCoreModule))]
    public class LibrarySystemForDemoWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LibrarySystemForDemoWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibrarySystemForDemoWebHostModule).GetAssembly());
        }
    }
}
