//using jautomulti.Data;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace jautomulti.Controllers.API
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AccountApiController : ControllerBase
//    {
//        private readonly SignInManager<ApplicationUser> _signInManager;
//        private readonly UserManager<ApplicationUser> _userManager;

//        public AccountApiController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
//        {
//            _signInManager = signInManager;
//            _userManager = userManager;
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login(LoginModel model)
//        {
//            var user = await _userManager.FindByNameAsync(model.UserName);

//            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
//            {
//                await _signInManager.SignInAsync(user, isPersistent: false);
//                return Ok();
//            }

//            return Unauthorized();
//        }

//        [HttpPost("register")]
//        public async Task<IActionResult> Register(RegisterModel model)
//        {
//            var user = new ApplicationUser { UserName = model.UserName};
//            var result = await _userManager.CreateAsync(user, model.Password);

//            if (result.Succeeded)
//            {
//                await _signInManager.SignInAsync(user, isPersistent: false);
//                return Ok();
//            }

//            return BadRequest(result.Errors);
//        }

//        [Authorize]
//        [HttpGet("protected-route")]
//        public IActionResult ProtectedRoute()
//        {
//            // Only authenticated users can access this route
//            // You can access the authenticated user's information using User.Identity

//            // Return dummy data as an example
//            var dummyData = new { message = "This is protected data!" };
//            return Ok(dummyData);
//        }
//    }

//    public class LoginModel
//    {
//        public string UserName { get; set; }
//        public string Password { get; set; }
//    }

//    public class RegisterModel
//    {
//        public string UserName { get; set; }
//        public string Password { get; set; }
//    }
//}

using jautomulti.Data;
using jautomulti.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace jautomulti.Controllers.API
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountApiController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok(); // Registration successful
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return Ok(); // Login successful
                }
                else
                {
                    return BadRequest("Invalid login attempt");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        private async Task<bool> IsValidUser(string username, string password)
        {

            var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }
        [HttpGet]
        public IActionResult GetAccountApi()
        {
            // Implementação do método de rota /api/accountapi GET
            return Ok("API accountapi");
        }
    }
}
