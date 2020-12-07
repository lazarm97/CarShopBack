using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Address;
using Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    [Route("api/Address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        // GET: api/Address
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Address/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Address
        [HttpPost]
        public IActionResult Post()
        {
            return Ok("asd");
        }

        // PUT: api/Address
        [HttpPut()]
        public IActionResult Put
            (
            [FromBody] AddressCreateDto dto,
            [FromServices] ICreateAddressCommand command
            )
        {
            command.Execute(dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(
            int id,
            [FromServices] IDeleteAddressCommand command
            )
        {
            command.Execute(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
