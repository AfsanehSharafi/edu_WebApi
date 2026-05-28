using Application.Contracts;
using Application.Features.Categories.Requests.Commands;
using Application.Features.Categories.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/category
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        // GET: api/category
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetCategoryListRequest());
            return Ok(result);
        }

        //GET: api/category/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result= await _mediator.Send(new GetCategoryDetailRequest { Id = id});
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


    }
}
