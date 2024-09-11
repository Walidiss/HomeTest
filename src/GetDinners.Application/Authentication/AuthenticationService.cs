using GetDinners.Application.Authentication.Common;
using GetDinners.Application.Common.Authentication;
using GetDinners.Application.Persistance;
using GetDinners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Application.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwTokenGeneration _jwTokenGeneration;
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IJwTokenGeneration jwTokenGeneration, IUserRepository userRepository)
        {
            _jwTokenGeneration = jwTokenGeneration;
            _userRepository = userRepository;

        }
        public AuthenticationResult Login(string email , string password)
        {

            if(_userRepository.GetUserByEmail(email) is not User user)
            {

                throw new Exception("user not found");
            }

            if(user.Password !=  password)
            {
                throw new Exception("Invalid password");
            }


            var token = _jwTokenGeneration.GenerateToken(user.Id,user.FirstName,user.LastName);
            return new AuthenticationResult(user, token);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email,string password)
        {
            //check if user exist
            if(_userRepository.GetUserByEmail(email) is not null)
            {

              throw new Exception("user already exist");

            }
            User user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            //create user unique id
            _userRepository.AddUser(user);

            //generate token
            var token = _jwTokenGeneration.GenerateToken(user.Id, user.FirstName, user.LastName);


            return new AuthenticationResult(user, token);
        }
    }
}
