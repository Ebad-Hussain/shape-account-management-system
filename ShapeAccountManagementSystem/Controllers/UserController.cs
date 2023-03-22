using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShapeAccountManagementSystem.Core.Entities;
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

        public UserController(IMapper mapper,IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> SignUp(UserReceivableDto input)
        {
            bool result = await _userService.CreateUser(_mapper.Map<User>(input));
            if (result) return Ok(new ResponseModel(result, (int)HttpStatusCode.OK, true));
            else return BadRequest(new ResponseModel
                (result, (int)HttpStatusCode.BadRequest, false, "Email is already registered"));
        }

    }
}
