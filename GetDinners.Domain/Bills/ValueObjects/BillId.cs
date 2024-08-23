﻿using GetDinners.Domain.Common.Models;
using GetDinners.Domain.Dinners.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Bills.ValueObjects
{
    public sealed class BillId : ValueObject
    {

       public Guid Value {  get;}

        private BillId(Guid value)
        {
            Value = value;
        }

        public static BillId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;  
        }

    }
}
