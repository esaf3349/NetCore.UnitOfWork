using NetCore.UnitOfWork.Core.Entities.Common;
using System.Collections.Generic;

namespace NetCore.UnitOfWork.Core.Entities
{
    public class Chat : SoftDeleteEntity
    {
        public Chat()
        {
            Messages = new HashSet<Message>();
        }

        public string Name { get; set; }

        public ICollection<Message> Messages { get; private set; }
    }
}
