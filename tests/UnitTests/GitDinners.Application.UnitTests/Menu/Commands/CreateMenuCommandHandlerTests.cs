using FluentAssertions;
using GetDinners.Application.Menus.Commands;
using GetDinners.Application.Persistance;
using GitDinners.Application.UnitTests.Menu.Commands.TestUtils;
using GitDinners.Application.UnitTests.TestUtils.Menus.Extensions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GitDinners.Application.UnitTests.Menu.Commands
{
    public class CreateMenuCommandHandlerTests
    {
        private readonly CreateMenuCommandHandler _commandHandler;
        private readonly Mock<IMenuRepository> _menuRepositoryMock;
        public CreateMenuCommandHandlerTests()
        {
            _menuRepositoryMock= new Mock<IMenuRepository>();
            _commandHandler = new CreateMenuCommandHandler(_menuRepositoryMock.Object);
        }
        //T1: system unit to test: logical component we are testing
        //T2: scenario: what we are testing
        //T3: Expected outcome - what we expect the logical component to do
        [Theory]
        [MemberData(nameof(ValidCreateMenuCommands))]
        public async Task HandleCreateMenuCommand_WhenMenuIsValid_SouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
        {
            //Act 
            var result = await _commandHandler.Handle(createMenuCommand, default);

            //Assert
            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(createMenuCommand);
            _menuRepositoryMock.Verify(m =>m.AddMenu(result.Value), Times.Once);

        }

        public static IEnumerable<object[]> ValidCreateMenuCommands()
        {
            yield return new[] { CreateMenuCommandUtils.CreateMenuCommand() };
            yield return new[]
            { CreateMenuCommandUtils.CreateMenuCommand(
                sections: CreateMenuCommandUtils.CreateMenuSectionCommand(sectionCount:3)),
            };

            yield return new[]
           { CreateMenuCommandUtils.CreateMenuCommand(
                sections: CreateMenuCommandUtils.CreateMenuSectionCommand(
                items: CreateMenuCommandUtils.CreateMenuItemCommand(itemCount:3)    
                ,sectionCount:3)),
            };
        }
    }
}
