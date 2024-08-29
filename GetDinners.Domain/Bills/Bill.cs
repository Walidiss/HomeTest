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
    public class Bill : AggregateRoot<BillId,Guid>
    {

        public DinnerId DinnerId { get; private set; }
        public GuestId GuestId { get; private set; }
        public HostId HostId { get; private set; }
        public Price Price { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

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
        #pragma warning disable CS8618

                private Bill()
                {

                }
        #pragma warning restore CS8618
        public Bill Create(GuestId guestId, HostId hostId, Price price)
        {
            return new(BillId.CreateUnique(), guestId, hostId, price, DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}
