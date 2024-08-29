using GetDinners.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Menus.ValueObjects
{
    public sealed class MenuId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set;}

        private MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId CreateUnique()
        {

            return new(Guid.NewGuid());

        }
        public static MenuId Create(Guid value)
        {

        return new(value); 
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
#pragma warning disable CS8618

        private MenuId()
        {
        }

#pragma warning restore CS8618
    }
}
