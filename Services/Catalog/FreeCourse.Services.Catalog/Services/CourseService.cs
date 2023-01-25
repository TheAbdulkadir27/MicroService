using AutoMapper;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FreeCourse.Services.Catalog.Services
{
    using FreeCourse.Services.Catalog.Dtos;
    using Models;
    using Settings;
    using Shared;
    using Shared.Dtos;
    public class CourseService : ICourseService
    {
        private readonly IMongoCollection<Course> CourseCollection;
        private readonly IMongoCollection<Category> CategoryCollection;
        private readonly IMapper mapper;
        public CourseService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var Client = new MongoClient(databaseSettings.ConnectionString);
            var database = Client.GetDatabase(databaseSettings.DatabaseName);
            CourseCollection = database.GetCollection<Course>(databaseSettings.CourseCollectionName);
            CategoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            this.mapper = mapper;
        }
        public async Task<Response<List<CourseDto>>> GetAllAsync()
        {
            var courses = await CourseCollection.Find(course => true).ToListAsync();
            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await CategoryCollection.Find<Category>(v => v.Id == course.CategoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Course>();
            }
            return Response<List<CourseDto>>.Success(mapper.Map<List<CourseDto>>(courses), 200);
        }
        public async Task<Response<CourseDto>> GetByIdAsync(string id)
        {
            var course = await CourseCollection.Find(v => v.Id == id).FirstOrDefaultAsync();
            if (course == null)
            {
                return Response<CourseDto>.Fail("Course Not Found", 404);
            }
            course.Category = await CategoryCollection.Find(v => v.Id == course.CategoryId).FirstOrDefaultAsync();
            return Response<CourseDto>.Success(mapper.Map<CourseDto>(course), 200);
        }

        public async Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userid)
        {
            var courses = await CourseCollection.Find<Course>(x => x.UserId == userid).ToListAsync();
            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await CategoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstOrDefaultAsync();
                }
            }
            else
            {
                courses = new List<Course>();
            }
            return Response<List<CourseDto>>.Success(mapper.Map<List<CourseDto>>(courses), 200);
        }
        public async Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreate)
        {
            var newCourse = mapper.Map<Course>(courseCreate);
            newCourse.CreationDate = System.DateTime.Now;
            await CourseCollection.InsertOneAsync(newCourse);
            return Response<CourseDto>.Success(mapper.Map<CourseDto>(newCourse), 200);
        }
        public async Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdate)
        {
            var UpdateCourse = mapper.Map<Course>(courseUpdate);
            var result = await CourseCollection.FindOneAndReplaceAsync(x => x.Id == courseUpdate.Id, UpdateCourse);
            if (result == null)
            {
                return Response<NoContent>.Fail("Course Not Found", 404);
            }
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await CourseCollection.DeleteOneAsync(x => x.Id == id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else return Response<NoContent>.Fail("Course Not Found", 404);
        }
    }
}
