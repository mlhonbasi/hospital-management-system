using HospitalManagementSystem.WebUI.Dtos.LoginDtos;
using HospitalManagementSystem.WebUI.Dtos.TokenDtos;
using Newtonsoft.Json;
using System.Text;

namespace HospitalManagementSystem.WebUI.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _client;

        public LoginService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var jsonData = JsonConvert.SerializeObject(dto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await _client.PostAsync("https://localhost:7141/api/auth/login", stringContent);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return null;
            }

            var responseJson = await responseMessage.Content.ReadAsStringAsync();

            var tokenResponse = JsonConvert.DeserializeObject<TokenResponseDto>(responseJson);

            return tokenResponse.Token;
        }
    }
}
