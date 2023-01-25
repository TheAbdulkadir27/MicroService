using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Shared.BaseController
{
    public class CustomerBaseController : ControllerBase
    {
        public IActionResult CreateInstanceResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
