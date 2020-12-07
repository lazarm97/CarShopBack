using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Mobile;
using Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        // GET: api/Mobile
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mobile/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mobile
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Mobile/5
        [HttpPut()]
        public IActionResult Put
            (
            [FromBody] MobileCreateDto dto,
            [FromServices] ICreateMobileCommand command
            )
        {
            command.Execute(dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(
            int id,
            [FromServices] IDeleteMobileCommand command
            )
        {
            command.Execute(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
