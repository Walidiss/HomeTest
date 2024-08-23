using GetDinners.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Users.ValueObjects
{
    public sealed class UserId : ValueObject
    {
        public Guid Value { get; private set; }

        private UserId(Guid value)
        {
            Value = value;         
        }

        public static UserId CreateUnique()
        {
            return new UserId(Guid.NewGuid());
        }


        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }
    }
}
