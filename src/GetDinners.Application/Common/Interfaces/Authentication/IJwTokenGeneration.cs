using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Application.Common.Authentication
{
    public interface IJwTokenGeneration
    {
        string GenerateToken(Guid userId, string firstName, string lastName);
    }
}
