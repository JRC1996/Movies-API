using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies_API.Models.Response;
using Movies_API.Models.Services;
using Movies_API.Models.Viewmodels;

namespace Movies_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUserService _userService;

        public UsersController(IUserService userService) 
        {
            _userService = userService;

        } 



        [HttpPost("login")]
        public IActionResult Auth([FromBody] AuthViewmodel model) 
        {
            var response = new Response();

            var userResponse = _userService.Auth(model);

            if (userResponse == null) 
            {
                response.Success = 0;
                response.Message = "Incorrect user name or password";
                return BadRequest(response);
            
            }

            response.Success = 1;
            response.Message = "All ok";
            response.Data = userResponse;

            return Ok(response);
        
        }
    }
}
