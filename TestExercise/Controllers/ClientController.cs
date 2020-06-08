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
            if(result.ErrorModels.Count > 0)
            {
                return new BadRequestObjectResult(result.ErrorModels);
            }
            return Ok();
          
        }


        [HttpDelete]
        [Route("api/delete")]
        public IActionResult Delete()
        {
            return Ok();
        }

    }
}
