using GetDinners.Domain.Common.Models;
using GetDinners.Domain.Common.ValueObjects;
using GetDinners.Domain.Dinners.ValueObjects;
using GetDinners.Domain.Guests.ValueObjects;
using GetDinners.Domain.Hosts.ValueObjects;
using GetDinners.Domain.MenuReview.ValueObjects;
using GetDinners.Domain.Menus.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.MenuReview
{
    public sealed class MenuReview :Entity<MenuReviewId>
    {
        public Rating Rating { get; }
        public string Comment { get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public GuestId GuestId { get; }
        public DinnerId DinnerId { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private MenuReview(MenuReviewId menuReviewId, string comment, HostId hostId, MenuId menuId, GuestId guestId, DinnerId dinnerId, DateTime createdDateTime, DateTime updatedDateTime): base(menuReviewId)
        {
            Comment = comment;
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            DinnerId = dinnerId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static MenuReview Create(string comment, HostId hostId, MenuId menuId, GuestId guestId, DinnerId dinnerId)
        {
            return new(MenuReviewId.CreateUnique(), comment, hostId, menuId, guestId, dinnerId, DateTime.UtcNow, DateTime.UtcNow);
        }

    }
}
