using GetDinners.Domain.Common.Models;
using GetDinners.Domain.Common.ValueObjects;
using GetDinners.Domain.Dinners.ValueObjects;
using GetDinners.Domain.Hosts.ValueObjects;
using GetDinners.Domain.Menus.ValueObjects;
using GetDinners.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Hosts
{
    public sealed class Host : AggregateRoot<HostId, Guid>
    {

        private readonly List<MenuId> _menuIds = new();
        private readonly List<DinnerId> _dinnerIds = new();

        public string FirstName {get; private set; }
        public string LastName {get; private set; }
        public string ProfileImage {get; private set; }
        public AverageRating AverageRating {get; private set; }
        public UserId UserId {get; private set; }

        public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public DateTime CreatedDateTime {get; private set; }
        public DateTime UpdatedDateTime {get; private set; }


        private Host(HostId hostId, string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(hostId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Host Create(string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        {
            return new(HostId.CreateUnique(), firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
        }

        public void AddMenuId(MenuId menuId)
        {
            _menuIds.Add(menuId);
        }

        public void AddDinnerId(DinnerId dinnerId)
        {
            _dinnerIds.Add(dinnerId);
        }
         

#pragma warning disable CS8618

        private Host()
        {
        }

#pragma warning restore CS8618

    }
}
