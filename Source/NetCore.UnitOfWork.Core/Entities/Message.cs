using NetCore.UnitOfWork.Core.Entities.Common;
using System;

namespace NetCore.UnitOfWork.Core.Entities
{
    public class Message : IntKeyEntity
    {
        public string Content { get; set; }
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public DateTime SendTime { get; set; }

        public Chat Chat { get; set; }
        public Person Sender { get; set; }
    }
}
