using System.Threading.Tasks;
using EduVise.Models.TokenAuth;
using EduVise.Web.Controllers;
using Shouldly;
using Xunit;

namespace EduVise.Web.Tests.Controllers
{
    public class HomeController_Tests: EduViseWebTestBase
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