using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Settings;
using FreeCourse.Shared;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> CategoryCollection;
        private readonly IMapper mapper;
        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            CategoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            this.mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var Category = await CategoryCollection.Find(category => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(mapper.Map<List<CategoryDto>>(Category), 200);
        }
        public async Task<Response<CategoryDto>> CreateCategory(CategoryDto category)
        {
            var category1 = mapper.Map<Category>(category);
            await CategoryCollection.InsertOneAsync(category1);
            return Response<CategoryDto>.Success(mapper.Map<CategoryDto>(category), 200);
        }
        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await CategoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return Response<CategoryDto>.Fail("Category Not Found", 404);
            }
            return Response<CategoryDto>.Success(mapper.Map<CategoryDto>(category), 200);
        }
    }
}
