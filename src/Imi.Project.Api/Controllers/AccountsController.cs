using Imi.Project.Api.Core.Constants;
using Imi.Project.Api.Core.Dtos.Users;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public AccountsController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto loginRequestDto)
        {
            if (!ModelState.IsValid)
                return Unauthorized(ModelState);

            var user = await _userManager.FindByEmailAsync(loginRequestDto.Login) ?? await _userManager.FindByNameAsync(loginRequestDto.Login);

            if (user is null)
                return Unauthorized("Login name, email or password is incorrect");

            var result = await _signInManager.PasswordSignInAsync(user, loginRequestDto.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
                return Unauthorized("Login password is incorrect");

            var token = await _tokenService.GenerateTokenAsync(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            _ = int.TryParse(_configuration["Jwt:RefreshTokenValidityInDays"], out int refreshTokenExpiration);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenExpiration);

            await _userManager.UpdateAsync(user);

            return Ok(
                new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo.ToLocalTime()
                }
            );
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserRequestDto registerUserRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Check if user with username already exists
            var userExists = await _userManager.FindByNameAsync(registerUserRequestDto.UserName);

            if (userExists is not null)
                return BadRequest($"User with username({registerUserRequestDto.UserName}) already exists");

            // Check if user with email already exists
            var emailExists = await _userManager.FindByEmailAsync(registerUserRequestDto.Email);

            if (emailExists is not null)
                return BadRequest($"User with this email({registerUserRequestDto.Email}) already exists");

            // Create new user
            var newUser = new User
            {
                UserName = registerUserRequestDto.UserName,
                Email = registerUserRequestDto.Email,
                PhoneNumber = registerUserRequestDto.PhoneNumber,
                Firstname = registerUserRequestDto.FirstName,
                Lastname = registerUserRequestDto.LastName,
                DateOfBirth = registerUserRequestDto.DateOfBirth,
                HasApprovedTermsAndConditions = registerUserRequestDto.HasApprovedTermsAndConditions
            };

            var result = await _userManager.CreateAsync(newUser, registerUserRequestDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                return BadRequest(errors);
            }

            // Override newuser
            newUser = await _userManager.FindByNameAsync(registerUserRequestDto.UserName);

            var claims = new List<Claim>()
            {
                new Claim(CustomClaimTypes.HasApproved, registerUserRequestDto.HasApprovedTermsAndConditions.ToString(), ClaimValueTypes.Boolean),
                new Claim(ClaimTypes.NameIdentifier, newUser.Id, ClaimValueTypes.String),
            };

            await _userManager.AddClaimsAsync(newUser, claims);

            // Userrole to new user
            await _userManager.AddToRoleAsync(newUser, CustomRoles.User);

            return Ok();
        }

        /// <summary>
        /// Get RefreshToken
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("refreshtoken")]
        public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
        {
            if (tokenModel is null)
            {
                return BadRequest("Invalid client request");
            }

            string accessToken = tokenModel.AccessToken;
            string refreshToken = tokenModel.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                return BadRequest("Invalid access token or refresh token");
            }

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string username = principal.Identity.Name;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            var newAccessToken = await _tokenService.GenerateTokenAsync(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return Ok(
                new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                    RefreshToken = newRefreshToken,
                    Expiration = newAccessToken.ValidTo.ToLocalTime()
                }
            );
        }
    }
}