using Microsoft.AspNetCore.Mvc;
using ST.API.Contracts;
using ST.Application.Feature.Categories.Command.UpdateCategory;
using ST.Application.Feature.Categories.Commands.CreateCategory;
using ST.Application.Feature.Categories.Commands.DeleteCategory;
using ST.Application.Feature.Categories.Query.GetAllCategory;
using ST.Application.Feature.Categories.Query.GetCategoryById;
using ST.Contracts.Category;
using System;
using System.Threading.Tasks;

namespace ST.API.Controllers.V1
{
    [ApiController]
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route(ApiRoutesV1.Category.GetAll)]
        public async Task<IActionResult> GetAllAsync([FromQuery] string search, [FromQuery] int pageSize, [FromQuery] int pageNumber = 1)
        {
            var query = new GetAllCategoryQuery(search, pageSize);
            return Ok(await Mediator.Send(query));
        }


        [HttpGet]
        [Route(ApiRoutesV1.Category.GetById)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var query = new GetCategoryByIdQuery(id);
            return Ok(await Mediator.Send(query));
        }
        [HttpPost]
        [Route(ApiRoutesV1.Category.Create)]
        public async Task<IActionResult> CreateAsync(CategoryRequest categoryRequest)
        {
            var command = new CreateCategoryCommand(categoryRequest);
            return Ok(await Mediator.Send(command));
        }
        [HttpPut]
        [Route(ApiRoutesV1.Category.Update)]
        public async Task<IActionResult> UpdateAsync(CategoryRequest request, Guid id)
        {
            var command = new UpdateCategoryCommand(id, request);
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete]
        [Route(ApiRoutesV1.Category.Delete)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var command = new DeleteCategoryCommand(id);
            return Ok(await Mediator.Send(command));
        }

    }
}
