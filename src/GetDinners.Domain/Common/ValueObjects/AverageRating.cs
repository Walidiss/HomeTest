﻿using GetDinners.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Common.ValueObjects
{
    public sealed class AverageRating : ValueObject
    {
        public double Value { get; private set; }
        public int NumRatings { get; private set; }
        private AverageRating(double value, int numRatings)
        {
            Value = value;
            NumRatings = numRatings;
        }

        public static AverageRating CreateNew(double rating = 0, int numRatings = 0)
        {
            return new AverageRating(rating, numRatings);
        }

        public void AddNewRating(Rating rating)
        {
            Value = (Value * NumRatings) + rating.Value / NumRatings++;

        }

        public void RemoveRating(Rating rating)
        {
            Value = (Value * NumRatings) - rating.Value / NumRatings--;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;

        }
    }
}
