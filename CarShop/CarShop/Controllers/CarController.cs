using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.Car;
using Application.DTO;
using Application.Queries.Car;
using Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public CarController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/Car
        [HttpGet]
        public IActionResult Get(
            [FromServices] IGetCarsQuery query,
            [FromQuery] CarSearch search)
        {
            return Ok(executor.ExecuteQuery(query,search));
        }

        // GET: api/Car/5
        [HttpGet("{id}")]
        public IActionResult Get(
            int id,
            [FromServices] IGetCarQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        [Authorize]
        [HttpPost("Images")]
        [DisableRequestSizeLimit, RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue, ValueLengthLimit = int.MaxValue)]
        public void Post(
            [FromForm] UploadCarDto dto,
            [FromServices] ICreateCarCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Car/5
        [Authorize]
        [HttpPut("{id}")]
        [RequestSizeLimit(long.MaxValue)]
        public void Put(
            int id, 
            [FromForm] CarEditDto dto,
            [FromServices] IEditCarCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IDeleteCarCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }

}
