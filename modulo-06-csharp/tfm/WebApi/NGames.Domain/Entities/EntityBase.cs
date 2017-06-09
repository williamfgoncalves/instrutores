using System.Collections.Generic;

namespace NGames.Domain.Entities
{
    public abstract class EntityBase
    {
        public List<string> Messages { get; private set; }

        public EntityBase()
        {
            Messages = new List<string>();
        }

        public bool IsValid()
        {
            return Messages.Count == 0;
        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
}