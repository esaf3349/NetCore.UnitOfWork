using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.UnitOfWork.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.UnitOfWork.EntityFramework.EntityConfigs.Common
{
    public abstract class SoftDeleteEntityConfig<T> : IntKeyEntityConfig<T> where T : SoftDeleteEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
