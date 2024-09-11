using GetDinners.Domain.Dinners.ValueObjects;
using GetDinners.Domain.Hosts;
using GetDinners.Domain.Hosts.ValueObjects;
using GetDinners.Domain.Menus;
using GetDinners.Domain.Menus.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Application.Persistance
{
    public interface IHostRepository
    {
        Task AddHost(Host host);

        Task<Host> GetHostByIdAsync(HostId id);

        Task SaveAsync(Host host);

        Task AddMenuId(HostId hostId, MenuId menuId);

        Task AddDinnerId(HostId hostId, DinnerId dinnerId);

    }
}
