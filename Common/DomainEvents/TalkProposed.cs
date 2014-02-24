using System;

namespace Common.DomainEvents
{
    public class TalkProposed : DomainEvent
    {
        public String Speaker { get; set; }
        public String Title { get; set; }
        public String Abstract { get; set; }
    }
}
