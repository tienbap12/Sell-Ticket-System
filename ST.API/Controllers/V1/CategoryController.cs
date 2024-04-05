using Microsoft.AspNetCore.Mvc;
using ST.API.Contracts;
using ST.Application.Feature.Categories.Command.CreateCategory;
using ST.Application.Feature.Categories.Command.DeleteCategory;
using ST.Application.Feature.Categories.Command.UpdateCategory;
using ST.Application.Feature.Categories.Query.GetAllCategory;
using ST.Application.Feature.Categories.Query.GetCategoryById;
using ST.Contracts.Category;
using System.Threading.Tasks;

namespace ST.API.Controllers.V1
{
    [ApiController]
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route(ApiRoutesV1.Category.GetAll)]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllCategoryQuery();
            return Ok(await Mediator.Send(query));
        }
        [HttpGet]
        [Route(ApiRoutesV1.Category.GetById)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetCategoryByIdQuery(id);
            return Ok(await Mediator.Send(query));
        }
        [HttpPost]
        [Route(ApiRoutesV1.Category.Create)]
        public async Task<IActionResult> CreateAsync(CategoryRequest categoryRequest)
        {
            var command = new CreateCategoryCommand(categoryRequest);
            return  Ok(await Mediator.Send(command));
        }
        [HttpPut]
        [Route(ApiRoutesV1.Category.Update)]
        public async Task<IActionResult> UpdateAsync(CategoryRequest request, int id)
        {
            var command = new UpdateCategoryCommand(id, request);
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete]
        [Route(ApiRoutesV1.Category.Delete)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteCategoryCommand(id);
            return Ok(await Mediator.Send(command));
        }
        
    }
}
