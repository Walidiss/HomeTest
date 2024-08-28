using GetDinners.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.MenuReview.ValueObjects
{
    public sealed class MenuReviewId : ValueObject
    {
        public Guid Value {get; private set; }

        private MenuReviewId(Guid value)
        {
           Value = value;             
        }
        public static MenuReviewId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public static MenuReviewId Create(Guid value)
        {
            return new(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
#pragma warning disable CS8618

        private MenuReviewId()
        {
        }

#pragma warning restore CS8618
    }
}
