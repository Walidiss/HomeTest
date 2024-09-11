using GetDinners.Domain.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Application.Persistance
{
    public interface IMenuRepository
    {
        void AddMenu(Menu menu);
    }
}
