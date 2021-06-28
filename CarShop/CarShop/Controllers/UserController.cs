using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using Application.Queries.User;
using Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public UserController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/User/Ban
        [Authorize]
        [HttpGet("Ban")]
        public IActionResult Get(
            [FromServices] IGetUserBanQuery query,
            [FromQuery] UserBanSearch search
            )
        {
            return Ok(executor.ExecuteQuery(query,search));
        }

        // GET: api/User/5
        [Authorize]
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(
            [FromServices] IGetUserQuery query,
            int id
            )
        {
            return Ok(executor.ExecuteQuery(query,id));
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post(
            [FromBody] CreateUserDto dto,
            [FromServices] ICreateUserCommand command
            )
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // POST: api/User/ForgotPassword
        [HttpPost("ForgotPassword")]
        public IActionResult Post(
            [FromBody] ForgotPasswordDto dto,
            [FromServices] IForgotUserPasswordCommand command
            )
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // POST: api/User/CreatePassword
        [HttpPost("CreatePassword")]
        public IActionResult Post(
            [FromBody] UserCreatePasswordDto dto,
            [FromServices] ICreateUserPasswordCommand command
            )
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // PUT: api/User/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
            [FromServices] IEditUserCommand command,
            [FromBody] UserEditDto dto)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // PUT: api/User/Password/5
        [Authorize]
        [HttpPut("Password/{id}")]
        public IActionResult Put(
            int id,
            [FromServices] IResetUserPasswordCommand command,
            [FromBody] ResetUserPasswordDto dto
            )
        {
            dto.IdUser = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // PUT: api/User/BanActivate/5
        [Authorize]
        [HttpPut("BanActivate/{id}")]
        public IActionResult Put(
            int id,
            [FromServices] IActivateBannedUserCommand command,
            [FromBody] UserBannedActivateDto dto
            )
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(
            [FromServices] IDeleteUserCommand command,
            int id
            )
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
