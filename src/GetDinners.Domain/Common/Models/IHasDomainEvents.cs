using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Common.Models
{
    public interface IHasDomainEvents
    {
        public IReadOnlyList<IDomainEvent> DomainEvents { get; }
        public void ClearDomainEvents();

        public void RemoveDomainEvent(IDomainEvent domainEvent);

    }
}
