using GetDinners.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Hosts.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public Guid Value { get; }
        private HostId(Guid value)
        {
            Value = value;
        }

        public static HostId CreateUnique()
        {
            return new HostId(Guid.NewGuid());
        }
        public static HostId Create(Guid value)
        {
            return new HostId(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }
    }
}
