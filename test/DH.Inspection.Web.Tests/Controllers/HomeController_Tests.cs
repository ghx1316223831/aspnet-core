using System.Threading.Tasks;
using DH.Inspection.Models.TokenAuth;
using DH.Inspection.Web.Controllers;
using Shouldly;
using Xunit;

namespace DH.Inspection.Web.Tests.Controllers
{
    public class HomeController_Tests: InspectionWebTestBase
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