using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.UnitOfWork.Core.Entities;
using NetCore.UnitOfWork.EntityFramework.EntityConfigs.Common;

namespace NetCore.UnitOfWork.EntityFramework.EntityConfigs
{
    public class PersonEntityConfig : SoftDeleteEntityConfig<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.FirstName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
