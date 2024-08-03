using GetDinner.Contracts.Authentication;
using GetDinners.Application.Authentication;
using GetDinners.Application.Authentication.Commands.Register;
using GetDinners.Application.Authentication.Queries;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetDinners.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var command = _mapper.Map<RegisterCommand>(registerRequest);

            var authentcationServiceResult = await _mediator.Send(command);

            return authentcationServiceResult.Match(
                authentcationServiceResult => Ok(_mapper.Map<AuthenticationResponse>(authentcationServiceResult)),
                errors => Problem(errors));

        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest  loginRequest)
        {

            var query = _mapper.Map<LoginQuery>(loginRequest);

            var authenticationServiceResult = await _mediator.Send(query);

            return authenticationServiceResult.Match(
                authenticationServiceResult => Ok(_mapper.Map<AuthenticationResponse>(authenticationServiceResult)),
                errors => Problem(errors)
                );
        }


    }
}
