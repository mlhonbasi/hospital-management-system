using HospitalManagementSystem.WebUI.Dtos.BranchDtos;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HospitalManagementSystem.WebUI.Services.BranchServices
{
    public class BranchService : IBranchService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BranchService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateBranchAsync(CreateBranchDto dto)
        {
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:5000/api/branches", stringContent);
        }

        public async Task DeleteBranchAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"https://localhost:5000/api/branches?id={id}");
        }

        public async Task<List<ResultBranchDto>> GetAllBranchesAsync()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("JwtToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseMessage = await _httpClient.GetAsync("https://localhost:5000/api/branches");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBranchDto>>(jsonData);
            return values;
        }

        public async Task<GetByIdBranchDto> GetBranchByIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"https://localhost:5000/api/branches/GetBranch?id={id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetByIdBranchDto>(jsonData);
            return values;
        }

        public async Task UpdateBranchAsync(UpdateBranchDto dto)
        {
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync("https://localhost:5000/api/branches", stringContent);
        }
    }
}
