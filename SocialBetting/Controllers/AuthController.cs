using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialBetting.DAL.DTOs;
using SocialBetting.DAL.Models;
using SocialBetting.DAL.Services.IDataService;

namespace SocialBetting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) 
        {
            _authService = authService;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> Register([FromBody] SignUpModel model)
        {
            if(!ModelState.IsValid)
            return BadRequest(new {message="Model State is not Valid"});
            
           bool checkEmail = await _authService.CheckEmailExsistence(model?.Email!);
            if(checkEmail)
            {
                return BadRequest(new { message = "Email Already Exist" });
            }
            SignUpDto dto = new SignUpDto()
            {
               FirstName = model.FirstName,
               LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password=model.Password,
                IsActive=true
            };
            await _authService.SignUp(model);
            return Ok(new {message = "User Register Successfully"});
        }
        
    }
}
