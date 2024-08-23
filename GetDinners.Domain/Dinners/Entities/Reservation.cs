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
        public int GuestCount { get; }
        public string ReservationStatus { get; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }
        public DateTime? ArrivalDateTime { get; private set; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

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
    }
}
