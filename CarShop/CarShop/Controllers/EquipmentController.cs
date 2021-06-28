using Application.Queries.Equipment;
using Application.Searches;
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
    public class EquipmentController : ControllerBase
    {
        // GET: api/<EquipmentController>
        [HttpGet]
        public IActionResult Get(
            [FromServices] IGetEquipmentsQuery query,
            [FromQuery] EquipmentSearch search)
        {
            return Ok(query.Execute(search));
        }

    }
}
