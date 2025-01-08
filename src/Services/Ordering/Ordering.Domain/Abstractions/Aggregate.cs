using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Abstractions
{
    public abstract class Aggregate<TId>:Entity<TId>, IAggregate<TId>
    {
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;
        private List<IDomainEvent> _domainEvents = new();

        public IDomainEvent[] ClearDomainEvents()
        {
            var events = _domainEvents.ToArray();
            _domainEvents.Clear();
            return events;
        }

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
    {
    }
}
