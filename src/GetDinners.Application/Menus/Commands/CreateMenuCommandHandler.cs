using ErrorOr;
using GetDinners.Application.Persistance;
using GetDinners.Domain.Hosts.ValueObjects;
using GetDinners.Domain.Menus;
using GetDinners.Domain.Menus.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Application.Menus.Commands
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand,ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

      public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var menu = Menu.Create(
                hostId: HostId.Create(request.HostId),
                name: request.Name,
                description: request.Description,
                sections:request.Sections.Select(sections => MenuSection.Create(
                    name:sections.Name,
                    description: sections.Description,
                    items: sections.Items.Select(items => MenuItem.Create(
                        name: items.Name,
                        description: items.Description                        
                        )).ToList()
                    )).ToList());

            _menuRepository.AddMenu(menu);

            return menu;
        }
    }
}
