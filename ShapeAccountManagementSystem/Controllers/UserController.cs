using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShapeAccountManagementSystem.Core.Dtos.Receivables;
using ShapeAccountManagementSystem.Core.Interfaces;
using ShapeAccountManagementSystem.Models;
using ShapeAccountManagementSystem.Models.Receivables;
using System.Net;

namespace ShapeAccountManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public UserController(IMapper mapper,IUserService userService, ILogger logger)
        {
            _mapper = mapper;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("signup", Name = "Signup")]
        public async Task<ActionResult<ResponseModel>> Signup(UserReceivableDto input)
        {
            _logger.LogInformation("Create User - Signup function called - User Controller");
            bool result = await _userService.CreateUser(_mapper.Map<CreateUserReceivableDto>(input));
            if (result) return Ok(new ResponseModel(result, (int)HttpStatusCode.OK, true, "User registered successfuly"));
            else return BadRequest(new ResponseModel
                (result, (int)HttpStatusCode.BadRequest, false, "Email is already registered"));
        }

        [HttpPost("login", Name ="Login")]
        public async Task<ActionResult<ResponseModel>> Login(LoginReceivableDto login)
        {
            _logger.LogInformation("Login - Login function called - User Controller");
            bool result = await _userService.Login(login.UserName, login.Password);
            if (result) return Ok(new ResponseModel(result, (int)HttpStatusCode.OK, true, "Login successful"));
            else return Unauthorized(new ResponseModel
                (result, (int)HttpStatusCode.BadRequest, false, "Invalid credentials"));
        }
    }
}
