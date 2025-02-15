﻿using GetDinners.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Bills.ValueObjects
{
    public sealed class Price : ValueObject
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        private Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Price CreateNew(decimal amount, string currency)
        {
            return new Price(amount, currency);
        }

#pragma warning disable CS8618

        private Price()
        {

        }
#pragma warning restore CS8618
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
