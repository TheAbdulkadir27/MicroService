using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : CustomerBaseController
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService courseService) => this.courseService = courseService;
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await courseService.GetByIdAsync(id);
            return CreateInstanceResultInstance(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await courseService.GetAllAsync();
            return CreateInstanceResultInstance(response);
        }

        [Route("/api/[controller]/GetByUserId/{userid}")]
        [HttpGet("userid")]
        public async Task<IActionResult> GetByUserId(string userid)
        {
            var response = await courseService.GetAllByUserIdAsync(userid);
            return CreateInstanceResultInstance(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto courseCreate)
        {
            var response = await courseService.CreateAsync(courseCreate);
            return CreateInstanceResultInstance(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto CourseUpdate)
        {
            var response = await courseService.UpdateAsync(CourseUpdate);
            return CreateInstanceResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await courseService.DeleteAsync(id);
            return CreateInstanceResultInstance(response);
        }
    }
}
