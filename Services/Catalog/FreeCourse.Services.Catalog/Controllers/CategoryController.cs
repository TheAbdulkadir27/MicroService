using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomerBaseController
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService) => this.categoryService = categoryService;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await categoryService.GetAllAsync();
            return CreateInstanceResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto category)
        {
            var response = await categoryService.CreateCategory(category);
            return CreateInstanceResultInstance(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var response = await categoryService.GetByIdAsync(id);
            return CreateInstanceResultInstance(response);
        }
    }
}
