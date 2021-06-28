using Application;
using Application.Commands.Color;
using Application.DTO;
using Application.Queries.Color;
using Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public ColorController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/<Colors>
        [HttpGet]
        public IActionResult Get(
            [FromServices] IGetColorsQuery query,
            [FromQuery] ColorSearch search)
        {
            return Ok(query.Execute(search));
        }

        // POST api/<Colors>
        [Authorize]
        [HttpPost]
        public void Post(
            [FromServices] ICreateColorCommand command,
            [FromBody] CreateColorDto dto
            )
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<Colors>/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(
            int id,
            [FromBody] ColorEditDto dto,
            [FromServices] IEditColorCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
        }

        // DELETE api/<Colors>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IDeleteColorCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
