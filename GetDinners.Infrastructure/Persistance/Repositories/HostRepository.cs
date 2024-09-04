using GetDinners.Application.Persistance;
using GetDinners.Domain.Hosts;
using GetDinners.Domain.Menus;
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
        public void AddHost(Host host)
        {
            _context.Add(host);
            _context.SaveChanges();
        }
    }
}
