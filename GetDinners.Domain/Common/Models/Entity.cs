﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>> ,IHasDomainEvents
            where TId : notnull
    {
        private List<IDomainEvent> _domainEvents = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public TId Id { get; protected set; }
        protected Entity(TId id)
        {
            Id = id;
        }
        public override bool Equals(object? obj)
        {
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }

        public bool Equals(Entity<TId>? other)
        {
            return Equals((object?)other);
        }
        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        //add domainEvent to the list of DomainEvents 
        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        // remove a domainEvent from the list of _domainEvents
        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }
        //clear the _domainEvent List 
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
#pragma warning disable CS8618

        protected Entity() { }

#pragma warning restore CS8618


    }
}
