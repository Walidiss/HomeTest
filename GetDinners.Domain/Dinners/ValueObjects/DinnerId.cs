using GetDinners.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Dinners.ValueObjects
{
    public sealed class DinnerId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }
        public DinnerId(Guid value)
        {
            Value = value;
        }

        public static DinnerId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static DinnerId Create(Guid Value)
        {
            return new(Value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }


#pragma warning disable CS8618

        private DinnerId()
        {
        }

#pragma warning restore CS8618
    }
}
