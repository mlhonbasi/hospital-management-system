using HospitalManagementSystem.WebUI.Dtos.BranchDtos;
using Newtonsoft.Json;
using System.Text;

namespace HospitalManagementSystem.WebUI.Services.BranchServices
{
    public class BranchService : IBranchService
    {
        private readonly HttpClient _httpClient;

        public BranchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
