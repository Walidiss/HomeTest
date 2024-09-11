using GetDinners.Application.Persistance;
using GetDinners.Domain.Common.ValueObjects;
using GetDinners.Domain.Dinners.ValueObjects;
using GetDinners.Domain.Hosts;
using GetDinners.Domain.Menus;
using GetDinners.Domain.Menus.Events;
using GetDinners.Domain.Menus.ValueObjects;
using GetDinners.Domain.Users.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Application.Menus.Events
{
    public class CreatedMenuHandler : INotificationHandler<CreatedMenuDomainEvent>
    {
        private readonly IHostRepository _hostRepository;

        public CreatedMenuHandler(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
        }

        public  async Task Handle(CreatedMenuDomainEvent notification, CancellationToken cancellationToken)
        {
            var menuId = new MenuId(notification.menu.Id.Value);
            //var menuId = MenuId.Create(notification.menu.Id);
            //var host = Host.Create("walid","issaoui", "toto", AverageRating.CreateNew(2, 5), userId:UserId.CreateUnique(), DateTime.UtcNow, DateTime.UtcNow);      
            await _hostRepository.AddMenuId(notification.menu.HostId, menuId);
           
        }
    }
}
