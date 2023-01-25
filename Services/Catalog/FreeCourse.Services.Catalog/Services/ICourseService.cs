using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Shared;
using FreeCourse.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Services
{
    public interface ICourseService
    {
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseDto>> GetByIdAsync(string id);
        Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userid);
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreate);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdate);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
