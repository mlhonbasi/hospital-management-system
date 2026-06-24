using AutoMapper;
using HospitalManagementSystem.ReviewService.Dtos.ReviewDtos;
using HospitalManagementSystem.ReviewService.Entities;
using HospitalManagementSystem.ReviewService.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HospitalManagementSystem.ReviewService.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IMongoCollection<Review> _reviewCollection;
        private readonly IMapper _mapper;

        public ReviewService(IMapper mapper, IOptions<DatabaseSettings> settings)
        {
            var databaseSettings = settings.Value;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _reviewCollection = database.GetCollection<Review>(databaseSettings.ReviewCollectionName);

            _mapper = mapper;
        }
        public async Task CreateReviewAsync(CreateReviewDto dto)
        {
            var value = _mapper.Map<Review>(dto);
            await _reviewCollection.InsertOneAsync(value);
        }

        public async Task DeleteAsync(string id)
        {
            await _reviewCollection.DeleteOneAsync(id);
        }

        public async Task<List<ResultReviewDto>> GetAllAsync()
        {
            var value = await _reviewCollection.Find(x=> true).ToListAsync();
            var result = _mapper.Map<List<ResultReviewDto>>(value);
            return result;
        }

        public async Task<GetReviewByIdDto> GetReviewByIdAsync(string id)
        {
            var value = await _reviewCollection.FindAsync(x => x.ReviewId == id);
            var result = _mapper.Map<GetReviewByIdDto>(value);
            return result;

        }
    }
}
