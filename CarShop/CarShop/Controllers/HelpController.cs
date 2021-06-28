using Application;
using Application.Queries.Equipment;
using Application.Queries.Help;
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
    public class HelpController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public HelpController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/<HelpController>/NewCar
        [HttpGet("NewCar")]
        public IActionResult Get(
            [FromServices] IGetNewCarInfoQuery query,
            [FromQuery] NewCarInfoSearch search)
        {
            return Ok(executor.ExecuteQuery(query,search));
        }

        // GET: api/<HelpController>/NewReservation
        [Authorize]
        [HttpGet("NewReservation")]
        public IActionResult Get(
            [FromServices] IGetNewReservationInfoQuery query,
            [FromQuery] NewReservationInfoSearch search
            )
        {
            return Ok(executor.ExecuteQuery(query,search));
        }

    }
}
