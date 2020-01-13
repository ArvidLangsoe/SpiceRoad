using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Ping;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : MediatRController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPing()
        {
            var query = new PingQuery();
            var response = await Mediator.Send(query);
            return Ok(response);

        }
       


    }
}