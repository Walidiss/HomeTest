using GetDinners.Domain.Common.Models;
using GetDinners.Domain.Dinners.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Bills.ValueObjects
{
    public sealed class BillId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private BillId(Guid value)
        {
            Value = value;
        }

        public static BillId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public BillId()
        {
                
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;  
        }

    }
}
