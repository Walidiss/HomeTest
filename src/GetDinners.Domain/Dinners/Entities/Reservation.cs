using GetDinners.Domain.Bills.ValueObjects;
using GetDinners.Domain.Common.Models;
using GetDinners.Domain.Dinners.ValueObjects;
using GetDinners.Domain.Guests.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Dinners.Entities
{
    public sealed class Reservation : Entity<ReservationId>
    {
        public int GuestCount { get; private set; }
        public string ReservationStatus { get; private set; }
        public GuestId GuestId { get; private set; }
        public BillId BillId { get; private set; }
        public DateTime? ArrivalDateTime { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        public Reservation(ReservationId id, int guestCount, string reservationStatus, GuestId guestId, BillId billId, DateTime createdDateTime, DateTime updatedDateTime) : base(id)
        {
            GuestCount = guestCount;
            ReservationStatus = reservationStatus;
            GuestId = guestId;
            BillId = billId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public Reservation Create(int guestCount, string reservationStatus, GuestId guestId, BillId billId)
        {
            return new(ReservationId.CreateUnique(), guestCount, reservationStatus, guestId, billId, DateTime.UtcNow, DateTime.UtcNow);
        }

#pragma warning disable CS8618

        private Reservation()
        {
        }

#pragma warning restore CS8618
    }
}
