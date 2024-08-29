using GetDinners.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Users.ValueObjects
{
    public sealed class UserId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

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
#pragma warning disable CS8618

        private UserId()
        {
        }

#pragma warning restore CS8618
    }
}

