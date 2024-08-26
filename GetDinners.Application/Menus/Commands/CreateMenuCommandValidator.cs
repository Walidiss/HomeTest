using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Application.Menus.Commands
{
    public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidator() { 
        RuleFor(x=>x.Name).NotEmpty();
        RuleFor(x=>x.Description).NotEmpty();
        RuleFor(x=>x.Sections).NotEmpty();
        RuleFor(x=>x.HostId).NotEmpty();  
        
        }
    }
}
