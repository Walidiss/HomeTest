using GetDinners.Application.Persistance;
using GetDinners.Domain.Dinners.ValueObjects;
using GetDinners.Domain.Hosts;
using GetDinners.Domain.Hosts.ValueObjects;
using GetDinners.Domain.Menus;
using GetDinners.Domain.Menus.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Infrastructure.Persistance.Repositories
{
    public class HostRepository : IHostRepository
    {
        private readonly HomeTestDbContext _context;
        public HostRepository(HomeTestDbContext context)
        {
            _context = context;
        }
        public async Task AddHost(Host host)
        {
            _context.Add(host);
          await  _context.SaveChangesAsync();
        }

        public async Task<Host> GetHostByIdAsync(HostId id)
        {


            return _context.hosts.AsEnumerable().First(x => x.Id.Value == id.Value);
             
             
        }

        public async Task SaveAsync(Host host)
        {
            _context.hosts.Update(host);
           await _context.SaveChangesAsync();
        }

        // Add MenuId

        public async Task AddMenuId(HostId hostId, MenuId menuId)
        {
            var host = await GetHostByIdAsync(hostId);
            if (host is not null)
            {
                host.AddMenuId(menuId);
                await SaveAsync(host);
            }
        }


        //Add DinnerId
        public async Task AddDinnerId(HostId hostId,DinnerId dinnerId)
        {
            var host = await GetHostByIdAsync(hostId);
           
            if(host is not null)
            {
                host.AddDinnerId(dinnerId);
                await SaveAsync(host);
            }
        }

    }
}
