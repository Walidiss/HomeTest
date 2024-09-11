using GetDinners.Application.Persistance;
using GetDinners.Domain.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Infrastructure.Persistance.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly HomeTestDbContext _dbContext;

        public MenuRepository(HomeTestDbContext homeTestDbContext)
        {
            _dbContext = homeTestDbContext;
        }

        public void AddMenu(Menu menu)
        {
            _dbContext.Add(menu);
            _dbContext.SaveChanges();
        }
    }
}
