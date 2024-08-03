using ErrorOr;
using GetDinners.Application.Authentication.Common;
using GetDinners.Application.Common.Authentication;
using GetDinners.Application.Persistance;
using GetDinners.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Errors = GetDinners.Domain.Common.Errors;

namespace GetDinners.Application.Authentication.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwTokenGeneration _jwTokenGeneration;
        public LoginQueryHandler(IUserRepository userRepository, IJwTokenGeneration jwTokenGeneration)
        {
            _userRepository = userRepository;
            _jwTokenGeneration = jwTokenGeneration;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
           
            if(_userRepository.GetUserByEmail(request.Email) is not User user)
            {

                return Errors.Errors.Authentication.InvalidCredentials;

            }

            if(user.Password != request.Password)
            {
                return Errors.Errors.Authentication.InvalidCredentials;
            }

            var token = _jwTokenGeneration.GenerateToken(user.Id, user.FirstName, user.LastName);

            return new AuthenticationResult(user, token);
        }
    }
}
