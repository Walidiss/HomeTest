using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Common.Models;
public abstract class AggregateRoot<TId> : Entity<TId>
    where TId: notnull  /*: AggregateRootId<TIdType>*/
{
    //public new AggregateRootId<TIdType> Id { get; protected set; }

    protected AggregateRoot(TId id)
    {
        Id = id;
    }

    protected AggregateRoot()
    {
    }
}
