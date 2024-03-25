using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Runninghill.Sentence.Assessment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Infrastructure.Configurations
{
    internal class WordItemConfiguration : IEntityTypeConfiguration<WordItem>
    {
        public void Configure(EntityTypeBuilder<WordItem> builder)
        {
            builder.Property(p => p.Word)
                   .HasMaxLength(DataSchemaConstants.DEFAULT_WORD_LENGTH)
                   .IsRequired();
            builder.HasKey(p => p.Id);

            builder.HasOne(d => d.WordGroup).WithMany(p => p.Items)
                   .HasForeignKey(d => d.WordGroupId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_WordItem_WordGroup");
        }
    }
}
