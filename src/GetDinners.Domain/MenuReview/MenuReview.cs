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
    public sealed class MenuReview :AggregateRoot<MenuReviewId, Guid>
    {
        public Rating Rating {get; private set; }
        public string Comment {get; private set; }
        public HostId HostId {get; private set; }
        public MenuId MenuId {get; private set; }
        public GuestId GuestId {get; private set; }
        public DinnerId DinnerId {get; private set; }
        public DateTime CreatedDateTime {get; private set; }
        public DateTime UpdatedDateTime {get; private set; }

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
#pragma warning disable CS8618

        private MenuReview()
        {
        }

#pragma warning restore CS8618

    }
}
