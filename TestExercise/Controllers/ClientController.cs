﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestExercise.Handlers;
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

        [HttpDelete]
        [Route("api/delete")]
        public IActionResult Delete()
        {
            return Ok();
        }

    }
}