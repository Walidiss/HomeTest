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
        public List<Menu> Menus = new List<Menu>();
        public void AddMenu(Menu menu)
        {
            Menus.Add(menu);
        }
    }
}
