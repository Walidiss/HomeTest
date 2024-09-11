using GetDinners.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Dinners.ValueObjects
{
    public sealed class ReservationId : AggregateRootId<Guid>
    {

        public override Guid Value { get ; protected set; }

        private ReservationId(Guid value)
        {
            Value = value;
        }

        public static ReservationId CreateUnique()
        {
            return new ReservationId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }
#pragma warning disable CS8618

        private ReservationId()
        {
        }

#pragma warning restore CS8618

    }
}
