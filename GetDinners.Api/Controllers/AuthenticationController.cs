using GetDinner.Contracts.Authentication;
using GetDinners.Application.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetDinners.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService; 

        }



        [HttpPost("register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            var authenticationServiceResponse = _authenticationService.Register(registerRequest.FirstName,
                registerRequest.LastName,
                registerRequest.Email,
                registerRequest.Password);

            var response = new AuthenticationResponse(
                authenticationServiceResponse.user.Id,
                authenticationServiceResponse.user.FirstName,
                authenticationServiceResponse.user.LastName,
                authenticationServiceResponse.user.Email,
                authenticationServiceResponse.token); 

            return Ok(response);
        }


        [HttpPost("login")]
        public IActionResult Login(LoginRequest  loginRequest)
        {
            return Ok();

        }


    }
}
