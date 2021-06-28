using Application;
using Application.Commands.Reservation;
using Application.DTO;
using Application.Queries.Reservation;
using Application.Searches;
using Microsoft.AspNetCore.Authorization;
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
    public class ReservationController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public ReservationController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/<ReservationController>
        [Authorize]
        [HttpGet]
        public IActionResult Get(
            [FromServices] IGetReservationsQuery query,
            [FromQuery] ReservationSearch search
            )
        {
            return Ok(executor.ExecuteQuery(query,search));
        }

        // GET: api/<ReservationController>/Statistic
        [Authorize]
        [HttpGet("Statistic")]
        public IActionResult Get(
            [FromServices] IGetReservationsStatisticQuery query,
            [FromQuery] ReservationStatisticSearch search
            )
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/<ReservationController>
        [Authorize]
        [HttpGet("UserReservations")]
        public IActionResult Get(
            [FromServices] IGetReservationQuery query,
            [FromQuery] ReservationSearch search
            )
        {
            return Ok(executor.ExecuteQuery(query,search));
        }

        // POST api/<ReservationController>
        [Authorize]
        [HttpPost]
        public void Post(
            [FromServices] ICreateReservationCommand command,
            [FromBody] CreateReservationDto dto
            )
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<ReservationController>/5
        [Authorize]
        [HttpPut()]
        public void Put(
            [FromServices] IEditReservationCommand command,
            [FromBody] EditReservationDto dto
            )
        {
            executor.ExecuteCommand(command, dto);
        }

        // DELETE api/<ReservationController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(
            int id,
            [FromServices] IDeleteReservationCommand command
            )
        {
            executor.ExecuteCommand(command, id);
        }
    }
}
