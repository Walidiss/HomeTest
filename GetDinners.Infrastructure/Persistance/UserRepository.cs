using GetDinners.Application.Persistance;
using GetDinners.Domain.Entities;

namespace GetDinners.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {

        private static List<User> users = new();

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
         return  users.SingleOrDefault(x=>x.Email == email);
        }
    }
}
