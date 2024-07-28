using hf.Api.Requests;
using System.Net.Http.Json;

namespace hf.Api.IntegrationTests
{
    public class AuthController_Tests
    {
        [Fact]
        public async Task GetLogin_OnEmptyTable_ShouldSucceed()
        {
            // Arrange
            var application = new HFWebApplicationFactory();
            LoginRequest request = new LoginRequest("user", "password", "01");

            var client = application.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/auth/login", request);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}