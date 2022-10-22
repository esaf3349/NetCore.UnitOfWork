using NetCore.UnitOfWork.Core.Interfaces;

namespace NetCore.UnitOfWork.Core.Entities.Common
{
    public abstract class SoftDeleteEntity : IntKeyEntity, ISoftDeletable
    {
        public bool IsDeleted { get; set; }
    }
}
