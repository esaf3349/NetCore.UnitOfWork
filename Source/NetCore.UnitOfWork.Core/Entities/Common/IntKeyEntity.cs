using NetCore.UnitOfWork.Core.Interfaces;

namespace NetCore.UnitOfWork.Core.Entities.Common
{
    public abstract class IntKeyEntity : IIntKeyIdentifiable
    {
        public int Id { get; set; }
    }
}