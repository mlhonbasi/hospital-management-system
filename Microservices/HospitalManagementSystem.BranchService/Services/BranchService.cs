using AutoMapper;
using HospitalManagementSystem.BranchService.Dtos.BranchDtos;
using HospitalManagementSystem.BranchService.Entities;
using HospitalManagementSystem.BranchService.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HospitalManagementSystem.BranchService.Services
{
    public class BranchService : IBranchService
    {
        private readonly IMongoCollection<Branch> _branchCollection;
        private readonly IMapper _mapper;

        public BranchService(IMapper mapper, IOptions<DatabaseSettings> settings)
        {
            var databaseSettings = settings.Value;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _branchCollection = database.GetCollection<Branch>(databaseSettings.BranchCollectionName);

            _mapper = mapper;
        }

        public async Task CreateAsync(CreateBranchDto dto)
        {
            var value = _mapper.Map<Branch>(dto);
            await _branchCollection.InsertOneAsync(value);
        }

        public async Task DeleteAsync(string id)
        {
            await _branchCollection.DeleteOneAsync(x => x.BranchId == id);
        }

        public async Task<List<ResultBranchDto>> GetAllAsync()
        {
            var values = await _branchCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBranchDto>>(values);
        }

        public async Task<GetBranchByIdDto> GetByIdAsync(string id)
        {
            var value = await _branchCollection.Find(x => x.BranchId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetBranchByIdDto>(value);
        }

        public async Task UpdateAsync(UpdateBranchDto dto)
        {
            var value = _mapper.Map<Branch>(dto);
            await _branchCollection.FindOneAndReplaceAsync(x => x.BranchId == dto.BranchId, value);
        }
    }
}
