using FluentAssertions;
using GetDinners.Application.Menus.Commands;
using GetDinners.Domain.Menus;
using GetDinners.Domain.Menus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GitDinners.Application.UnitTests.TestUtils.Menus.Extensions
{
    public static partial class MenuExtensions
    {
        public static void ValidateCreatedFrom(this GetDinners.Domain.Menus.Menu menu, CreateMenuCommand createMenuCommand)
        {
            menu.Name.Should().Be(createMenuCommand.Name);
            menu.Description.Should().Be(createMenuCommand.Description);
            // Valide que le nombre de sections du menu correspond au nombre de sections dans la commande.
            menu.Sections.Should().HaveSameCount(createMenuCommand.Sections);

            //Zip pour itérer sur les deux collections et valider chaque section individuellement.
            //Cette méthode associe les éléments des deux collections (les sections du menu et les sections de la commande) pour créer des paires.
            //Chaque paire contient un élément de menu.Sections et un élément correspondant de createMenuCommand.Sections
            menu.Sections.Zip(createMenuCommand.Sections).ToList().ForEach(pair=> ValidateSection(pair.First, pair.Second));

        }
        static void ValidateSection(MenuSection section, MenuSectionCommand menuSectionCommand)
        {
            section.Id.Should().NotBeNull();    
            section.Name.Should().Be(section.Name);
            section.Description.Should().Be(section.Description);
            section.Items.Should().HaveSameCount(menuSectionCommand.Items);
            section.Items.Zip(menuSectionCommand.Items).ToList().ForEach(pair => ValidateItem(pair.First, pair.Second));

        }

        static void ValidateItem( MenuItem menuItem, MenuItemCommand menuItemCommand)
        {
            menuItem.Id.Should().NotBeNull();
            menuItem.Name.Should().Be(menuItemCommand.Name);
            menuItem.Description.Should().Be(menuItemCommand.Description);        
        }




    }
}
