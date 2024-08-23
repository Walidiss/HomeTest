using GetDinners.Domain.Bills.ValueObjects;
using GetDinners.Domain.Common.Models;
using GetDinners.Domain.Dinners.ValueObjects;
using GetDinners.Domain.Guests.ValueObjects;
using GetDinners.Domain.Hosts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Bills
{
    public class Bill : Entity<BillId>
    {

        public DinnerId DinnerId { get; }
        public GuestId GuestId { get; }
        public HostId HostId { get; }
        public Price Price { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        public Bill(BillId id, GuestId guestId, HostId hostId, Price price, DateTime createdDateTime, DateTime updatedDateTime) : base(id)
        {
            {
                GuestId = guestId;
                HostId = hostId;
                Price = price;
                CreatedDateTime = createdDateTime;
                UpdatedDateTime = updatedDateTime;
            }
        }

        public Bill Create(GuestId guestId, HostId hostId, Price price)
        {
            return new(BillId.CreateUnique(), guestId, hostId, price, DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}
