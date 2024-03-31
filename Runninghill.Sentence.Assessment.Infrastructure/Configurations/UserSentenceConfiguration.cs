using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Runninghill.Sentence.Assessment.Domain.Entities;

namespace Runninghill.Sentence.Assessment.Infrastructure.Configurations
{
    public class UserSentenceConfiguration : IEntityTypeConfiguration<UserSentence>
    {
        public void Configure(EntityTypeBuilder<UserSentence> builder)
        {
            builder.Property(p => p.Text)
                   .HasMaxLength(DataSchemaConstants.DEFAULT_SENTENCE_CHARACTER_LENGTH)
                   .IsRequired();
        }
    }
}
