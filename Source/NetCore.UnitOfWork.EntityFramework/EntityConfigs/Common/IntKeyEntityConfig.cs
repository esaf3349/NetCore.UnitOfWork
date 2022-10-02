using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.UnitOfWork.Core.Entities.Common;

namespace NetCore.UnitOfWork.EntityFramework.EntityConfigs.Common
{
    public abstract class IntKeyEntityConfig<T> : IEntityTypeConfiguration<T> where T : IntKeyEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
