using ErrorOr;
using GetDinners.Application.Authentication.Common;
using GetDinners.Application.Common.Authentication;
using GetDinners.Application.Persistance;
using GetDinners.Domain.Entities;
using MediatR;
using Errors = GetDinners.Domain.Common.Errors;


namespace GetDinners.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwTokenGeneration _jwTokenGeneration;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository, IJwTokenGeneration jwTokenGeneration)
        {
            _jwTokenGeneration = jwTokenGeneration;

            _userRepository = userRepository;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(request.Email) is not null)
            {

                return Errors.Errors.User.DuplicateEmail;

            }

            var user = new User()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password
            };

            _userRepository.AddUser(user);

            var token = _jwTokenGeneration.GenerateToken(user.Id,user.FirstName,user.LastName);

            return new AuthenticationResult(user,token);
        }
    }
}
