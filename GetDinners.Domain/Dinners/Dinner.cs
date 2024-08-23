using GetDinners.Domain.Bills.ValueObjects;
using GetDinners.Domain.Common.Models;
using GetDinners.Domain.Dinners.Entities;
using GetDinners.Domain.Dinners.ValueObjects;
using GetDinners.Domain.Hosts.ValueObjects;
using GetDinners.Domain.Menus.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Dinners
{
    public sealed class Dinner : Entity<DinnerId>
    {
        private readonly List<Reservation> _reservations = new();

        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime? StartedDateTime { get; private set; }
        public DateTime? EndedDateTime { get; private set; }
        public string Status { get; }
        public bool IsPublic { get; }
        public int MaxGuests { get; }
        public Price Price { get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public string ImageUrl { get; }
        public Location Location { get; }

        public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }


        private Dinner(DinnerId dinnerId, string name, string description, DateTime startDateTime,
            DateTime endDateTime, string status, bool isPublic,
            int maxGuests, Price price, HostId hostId,
            MenuId menuId, string imageUrl, Location location,
            DateTime createdDateTime, DateTime updatedDateTime) : base(dinnerId)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Status = status;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Dinner Create(string name, string description, DateTime startDateTime,
            DateTime endDateTime, DateTime? startedDateTime, DateTime? endedDateTime,
            string status, bool isPublic, int maxGuests, Price price, HostId hostId,
            MenuId menuId, string imageUrl, Location location)
        {
            return new(DinnerId.CreateUnique(), name,
                description, startDateTime, endDateTime,
                status, isPublic, maxGuests, price, 
                hostId, menuId, imageUrl, location,
                DateTime.UtcNow, DateTime.UtcNow);
        }

    }
}
