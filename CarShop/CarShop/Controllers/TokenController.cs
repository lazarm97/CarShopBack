using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Helpers;
using CarShop.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtManager manager;
        private readonly IHashPassword _hashPassword;

        public TokenController(JwtManager manager, IHashPassword hashPassword)
        {
            this.manager = manager;
            _hashPassword = hashPassword;
        }

        // POST api/<TokenController>
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest request)
        {
            try
            {
                var password = _hashPassword.Encrypt(request.Password);
                var token = manager.MakeToken(request.Username, password);

                if (token == null)
                {
                    return Unauthorized();
                }

                return Ok(new { token });
            }catch(Exception ex)
            {
                return Ok(ex.Message);
            }
            
        }

        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}