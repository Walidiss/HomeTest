﻿using ErrorOr;
using GetDinners.Domain.Menus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Application.Menus.Commands
{
    public record CreateMenuCommand(
    Guid HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections) : IRequest <ErrorOr<Menu>>;

    public record MenuSectionCommand(string Name,
                              string Description,
                              List<MenuItemCommand> Items);
    public record MenuItemCommand(string Name,
                           string Description);

}
