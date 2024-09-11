using GetDinners.Domain.Common.Models;
using GetDinners.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Users
{
    public sealed class User : AggregateRoot<UserId, Guid>
    {

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        public User(UserId userId,
                    string firstName,
                    string lastName,
                    string email,
                    string password,
                    DateTime createdDateTime,
                    DateTime updatedDateTime) : base(userId)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static User Create(string firstName,
                                  string lastName,
                                  string email,
                                  string password) 
        {
            return new (
                UserId.CreateUnique(),
                firstName,
                lastName,
                email,
                password,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
#pragma warning disable CS8618

        private User()
        {
        }

#pragma warning restore CS8618
    }
}
