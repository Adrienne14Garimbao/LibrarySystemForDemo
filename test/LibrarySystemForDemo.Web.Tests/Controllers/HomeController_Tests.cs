using System.Threading.Tasks;
using LibrarySystemForDemo.Models.TokenAuth;
using LibrarySystemForDemo.Web.Controllers;
using Shouldly;
using Xunit;

namespace LibrarySystemForDemo.Web.Tests.Controllers
{
    public class HomeController_Tests: LibrarySystemForDemoWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}