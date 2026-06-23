using AutoMapper;
using HospitalManagementSystem.DoctorService.Dtos.DoctorDtos;
using HospitalManagementSystem.DoctorService.Entities;
using HospitalManagementSystem.DoctorService.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HospitalManagementSystem.DoctorService.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IMongoCollection<Doctor> _doctorCollection;
        private readonly IMapper _mapper;

        public DoctorService(IMapper mapper, IOptions<DatabaseSettings> settings)
        {
            var databaseSettings = settings.Value;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _doctorCollection = database.GetCollection<Doctor>(databaseSettings.DoctorCollectionName);

            _mapper = mapper;
        }
        public async Task CreateAsync(CreateDoctorDto dto)
        {
            var value = _mapper.Map<Doctor>(dto);
            await _doctorCollection.InsertOneAsync(value);
        }

        public async Task DeleteAsync(string id)
        {
            await _doctorCollection.DeleteOneAsync(id);
        }

        public async Task<List<ResultDoctorDto>> GetAllAsync()
        {
            var value = await _doctorCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDoctorDto>>(value);
        }

        public async Task<GetDoctorByIdDto> GetDoctorByIdAsync(string id)
        {
            var value = await _doctorCollection.FindAsync(x => x.DoctorId == id);
            return _mapper.Map<GetDoctorByIdDto>(value);
        }

        public async Task UpdateAsync(UpdateDoctorDto dto)
        {
            var value = _mapper.Map<Doctor>(dto);
            await _doctorCollection.FindOneAndReplaceAsync(x => x.DoctorId == dto.DoctorId, value);
        }
    }
}
