using GetDinners.Domain.Common.Models;
using GetDinners.Domain.Menus.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Menus.Entities
{
    public class MenuSection : Entity<MenuSectionId>
    {
        //utilisé pour empêcher la réassignation de la référence de la liste, mais permet toujours de modifier les éléments de la liste.
        private readonly List<MenuItem> _items = new();
        public String Name { get; set; }
        public String Description { get; set; }

        //utilisé pour exposer une liste de manière à ce que ses éléments ne puissent pas être modifiés par l'extérieur, garantissant une véritable immuabilité de l'accès.
        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();


        private MenuSection(MenuSectionId menuSectionId, string name, string description, List<MenuItem> items)
            : base(menuSectionId)
        {

            Name = name;
            Description = description;
            _items = items;
        }

        public static MenuSection Create(string name, string description, List<MenuItem> items)
        {
            return new MenuSection(MenuSectionId.CreateUnique(), name, description, items);
        }

    }
}
