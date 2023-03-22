using Microsoft.AspNetCore.Mvc;
using ShapeAccountManagementSystem.Models.Receivables;

namespace ShapeAccountManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

        [HttpPost]
        public void SignUp(SignUpReceivableDto input)
        {

        }

    }
}
