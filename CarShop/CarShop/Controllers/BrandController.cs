using Application;
using Application.Commands.Brand;
using Application.DTO;
using Application.Queries.Brand;
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
    public class BrandController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public BrandController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }


        // GET: api/<BrandController>
        [HttpGet]
        public IActionResult Get(
            [FromServices] IGetBrandsQuery query,
            [FromQuery] BrandSearch search)
        {
            return Ok(query.Execute(search));
        }

        // POST api/<BrandController>
        [Authorize]
        [HttpPost]
        public void Post(
            [FromServices] ICreateBrandCommand command,
            [FromBody] CreateBrandDto dto
            )
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<BrandController>/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(
            int id,
            [FromBody] BrandEditDto dto,
            [FromServices] IEditBrandCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
        }

        // DELETE api/<BrandController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IDeleteBrandCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
