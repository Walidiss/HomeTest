using GetDinners.Domain.Common.Models;
using GetDinners.Domain.Guests.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Guests
{
    public sealed class Guest : Entity<GuestId>
    {
        public Guest(GuestId id) : base(id)
        {
        }

    }
}
