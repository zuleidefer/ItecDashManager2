using ItecDashManager.Domain.Interfaces.ServiceInterfaces;
using ItecDashManager.WebApi.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace ItecDashManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] UserSignInViewModel model)
        {
            var user = await _userService.AuthenticateAsync(model.Email, model.Password);

            if (user == null)
                return Unauthorized(new { message = "Invalid email or password" });

            var token = _userService.GetTokenData(user);

            var response = new UserSignInResponseViewModel
            {
                Token = token.ToString(),
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return Ok(response);
        }
    }
}
