using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialBetting.CommonHelper.Middleware.JwtService;
using SocialBetting.DAL.DTOs;
using SocialBetting.DAL.Models;
using SocialBetting.DAL.Services.IDataService;
using SocialBetting.DAL.ViewModel;

namespace SocialBetting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthService authService, IConfiguration configuration) 
        {
            _authService = authService;
            _configuration = configuration;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> Register([FromBody] SignUpModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Model State is not Valid" });

            bool checkEmail = await _authService.CheckEmailExsistence(model?.Email!);
            if (checkEmail)
            {
                return BadRequest(new { message = "Email Already Exist" });
            }
            SignUpDto dto = new SignUpDto()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                IsActive = true,
                IsEmailVerified=true
            };
            await _authService.SignUp(model);
            return Ok(new { message = "User Register Successfully" });
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email)) return BadRequest("Email Required!");
            if (string.IsNullOrWhiteSpace(dto.Password)) return BadRequest("Password Required!");


            var result = await _authService.GetDataforAuth(dto.Email, dto.Password);

            if (result == null) return Unauthorized(new { message = "Invalid Email or Password" });
            if (result.IsEmailVerified == false)
            {
                return BadRequest(new { message = "Email not Verified" });
            }

            JWTToken tokens = new();
            var token = tokens.GenerateToken(result.UserId.ToString(), result.Email!, _configuration);

            AuthResponse response = new()
            {

                UserId = result.UserId,
                FirstName = result.FirstName,
                Email = result.Email,
                Token = token,
                IsActive = result.IsActive,
    
            };
            return Ok(response);
        }
        [HttpGet("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string email, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest(new { message = "User id is Required!" });

            if (string.IsNullOrWhiteSpace(password))
                return BadRequest(new { message = "User id is Required!" });

            if (!password.Equals(confirmPassword))
                return BadRequest(new { message = "Confirm Password Doesn't Match" });

            var checkEmail = await _authService.CheckEmailExsistence(email);


            if (checkEmail)
            {
                _authService.UpdatePasswordOnEmail(email, password);
                return Ok(new { message = "Your password has been reset!" });
            }
            if (!(checkEmail))
                return BadRequest(new { message = "User-Email Not Found Try Again!" });

            return BadRequest(new { message = "Issue Occured in Process!" });

        }
    }
}
