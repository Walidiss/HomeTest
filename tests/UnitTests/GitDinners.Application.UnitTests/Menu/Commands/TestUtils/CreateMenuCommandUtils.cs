using GetDinners.Application.Menus.Commands;
using GitDinners.Application.UnitTests.TestUtils.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GitDinners.Application.UnitTests.Menu.Commands.TestUtils
{
    public static class CreateMenuCommandUtils
    {

        public static CreateMenuCommand CreateMenuCommand(List<MenuSectionCommand>? sections = null) =>  
            new CreateMenuCommand(
                Constants.Host.Id.Value,
                Constants.Menu.Name,
                Constants.Menu.Description,
                sections ?? CreateMenuSectionCommand());
       

        public static List<MenuSectionCommand> CreateMenuSectionCommand(List<MenuItemCommand>? items = null,int sectionCount=1) =>       
            Enumerable.Range(0, sectionCount)
                .Select(index => new MenuSectionCommand(
                    Constants.Menu.SectionNameFromIndex(index),
                    Constants.Menu.SectionDescritpionFromIndex(index),
                    items ?? CreateMenuItemCommand()                   
                    )).ToList();
        

        public static List<MenuItemCommand> CreateMenuItemCommand(int itemCount=1) =>
            Enumerable.Range(0, itemCount)
                    .Select(index => new MenuItemCommand(
                        Constants.Menu.ItemNameFromIndex(index),
                        Constants.Menu.ItemDescriptionFromIndex(index))).ToList();

        

    }
}
