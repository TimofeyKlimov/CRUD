using System.Threading.Tasks;
using Domain.Contract;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestExercise.Commands;
using TestExercise.Queries;

namespace TestExercise.Controllers
{
    [ApiController]
    
    public class ClientController : ControllerBase
    {
        private readonly IMediator mediator;
        public ClientController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("api/get")]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetAllClientsQuery());
            return Ok(result);
        }

        [HttpPost]
        [Route("api/update")]
        public async Task<IActionResult> Update([FromBody] UpdateClientContract contract)
        {
            var result = await mediator.Send(new UpdateClientCommand(contract));
            if(result.ErrorModels?.Count > 0)
            {
                return new BadRequestObjectResult(result.ErrorModels);
            }
            return Ok();
          
        }
        [HttpPost]
        [Route("api/create")]
        public async Task<IActionResult> Create([FromBody] CreateClientContract contract)
        {
            var result = await mediator.Send(new CreateClientCommand(contract));
            if(result.ErrorModels?.Count > 0)
            {
                return new BadRequestObjectResult(result.ErrorModels);
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteClientContract contract)
        {
            var result = await mediator.Send(new DeleteClientCommand(contract));
            return Ok();
        }

    }
}
