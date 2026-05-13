using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project.DTOs;
using Project.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }

        [HttpPost("register")]
        public ActionResult Register(RegisterDTO dto)
        {
            var existingUser = _userManager.FindByEmailAsync(dto.Email).Result;
            if (existingUser != null)
                return BadRequest("Email is already registered");

            var user = new ApplicationUser
            {
                FullName = dto.FullName,
                Email = dto.Email,
                UserName = dto.Email
            };

            var result = _userManager.CreateAsync(user, dto.Password).Result;
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            if (!_roleManager.RoleExistsAsync(dto.Role).Result)
                _roleManager.CreateAsync(new IdentityRole(dto.Role)).Wait();

            _userManager.AddToRoleAsync(user, dto.Role).Wait();

            return Ok($"User registered successfully as {dto.Role}");
        }

        [HttpPost("login")]
        public ActionResult Login(LoginDTO dto)
        {
            var user = _userManager.FindByEmailAsync(dto.Email).Result;
            if (user == null)
                return Unauthorized("Invalid email or password");

            var passwordValid = _userManager.CheckPasswordAsync(user, dto.Password).Result;
            if (!passwordValid)
                return Unauthorized("Invalid email or password");

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }


        [HttpPost("logout")]
        public ActionResult Logout()
        {
            return Ok("Logged out successfully");
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName ?? user.Email),
            };

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["JWT:SecretKey"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(double.Parse(_config["JWT:ExpiryInDays"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}