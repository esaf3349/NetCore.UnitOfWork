using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.UnitOfWork.Core.Entities;
using NetCore.UnitOfWork.EntityFramework.EntityConfigs.Common;

namespace NetCore.UnitOfWork.EntityFramework.EntityConfigs
{
    public class MessageEntityConfig : SoftDeleteEntityConfig<Message>
    {
        public override void Configure(EntityTypeBuilder<Message> builder)
        {
            base.Configure(builder);

            builder.Property(m => m.Content)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(d => d.Chat)
                .WithMany(o => o.Messages)
                .HasForeignKey(d => d.ChatId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Sender)
                .WithMany(o => o.Messages)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
