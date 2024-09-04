using GetDinners.Domain.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Infrastructure.Persistance.Interceptors
{
    public class PublishDomainEventInterceptor : SaveChangesInterceptor
    {
        private readonly IPublisher _mediator;

        public PublishDomainEventInterceptor(IPublisher mediator)
        {
            _mediator = mediator;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            DispatchDomainEventsAsync(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await DispatchDomainEventsAsync(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        private async Task DispatchDomainEventsAsync(DbContext dbContext)
        {
            if (dbContext == null)
            {
                return;
            }

            // Get list of Entities with a domain Events 
            var entitiesWithDomainEvents = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
                .Where(entry => entry.Entity.DomainEvents.Any())
                .Select(entry => entry.Entity)
                .ToList();

            // Get list of domain events from the list of the entities with the domain events
            var domainEvents = entitiesWithDomainEvents
                .SelectMany(entry => entry.DomainEvents)
                .ToList();

            ////clear the domain events from the entities 
            foreach (var entityWithDomainEvent in entitiesWithDomainEvents)
            {
                entityWithDomainEvent.ClearDomainEvents();
            }

            //dispatch the domain events for the correspond domainEventHandler
            foreach (var domainEvent in domainEvents) {
             await _mediator.Publish(domainEvent);
            }

        }
    }
}
