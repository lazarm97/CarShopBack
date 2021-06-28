using Application;
using Application.Commands.Model;
using Application.DTO;
using Application.Queries.Model;
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
    public class ModelController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public ModelController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/<ModelController>
        [HttpGet]
        public IActionResult Get(
            [FromServices] IGetModelsQuery query,
            [FromQuery] ModelSearch search)
        {
            return Ok(query.Execute(search));
        }

        // POST api/<ModelController>
        [Authorize]
        [HttpPost]
        public void Post(
            [FromServices] ICreateModelCommand command,
            [FromBody] CreateModelDto dto
            )
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<ModelController>/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(
            int id,
            [FromBody] ModelEditDto dto,
            [FromServices] IEditModelCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
        }

        // DELETE api/<ModelController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IDeleteModelCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
