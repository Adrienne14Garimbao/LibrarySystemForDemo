using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LibrarySystemForDemo.Controllers;

namespace LibrarySystemForDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : LibrarySystemForDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
