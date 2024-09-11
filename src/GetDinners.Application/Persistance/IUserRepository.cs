using GetDinners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Application.Persistance
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);

        void AddUser(User user);

    }
}
