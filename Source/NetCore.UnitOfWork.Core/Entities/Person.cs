using NetCore.UnitOfWork.Core.Entities.Common;
using System.Collections.Generic;

namespace NetCore.UnitOfWork.Core.Entities
{
    public class Person : IntKeyEntity
    {
        public Person()
        {
            Messages = new HashSet<Message>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Message> Messages { get; private set; }
    }
}
