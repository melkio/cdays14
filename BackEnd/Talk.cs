using Common.DomainEvents;
using System;
using System.Collections.Generic;

namespace BackEnd
{
    public class Talk : AggregateRoot
    {
        private static Int32 Counter;

        public IEnumerable<DomainEvent> Propose(String speaker, String title, String @abstract)
        {
            if (String.IsNullOrEmpty(speaker))
                throw new ArgumentNullException("speaker");
            if (String.IsNullOrEmpty(@abstract))
                throw new ArgumentNullException("@abstract");

            yield return new TalkProposed
                {
                    Id = Guid.NewGuid().ToString(),
                    Speaker = speaker,
                    Title = title,
                    Abstract = @abstract
                };
        }

        public IEnumerable<DomainEvent> Approve()
        {
            if (Counter > 3)
                throw new InvalidOperationException("Isn't possible approve more than 3 talks");

            yield return new TalkApproved { Id = Id };
        }
    }
}
