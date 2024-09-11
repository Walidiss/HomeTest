using GetDinners.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Menus.Events
{
    public record CreatedMenuDomainEvent(Menu menu) : IDomainEvent;
}
