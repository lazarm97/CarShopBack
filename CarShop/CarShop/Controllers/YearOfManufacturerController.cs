using Application.Queries.YearOfManufacturer;
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
    public class YearOfManufacturerController : ControllerBase
    {
        // GET: api/<YearOfManufacturerController>
        [HttpGet]
        public IActionResult Get(
            [FromServices] IGetYearsOfManufacturerQuery query,
            [FromQuery] YearOfManufacturerSearch search)
        {
            return Ok(query.Execute(search));
        }

    }
}
