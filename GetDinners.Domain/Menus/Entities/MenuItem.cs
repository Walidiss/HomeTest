using GetDinners.Domain.Common.Models;
using GetDinners.Domain.Menus.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Menus.Entities
{
    public class MenuItem : Entity<MenuItemId>
    {

        public string Name { get; private set; }
        
        public string Description { get; private set;}

        public MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description) {

            return new MenuItem(MenuItemId.CreateUnique(),name,description);
        }
#pragma warning disable CS8618

        private MenuItem()
        {
        }

#pragma warning restore CS8618
    }
}
