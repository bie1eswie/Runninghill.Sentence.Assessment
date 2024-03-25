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
    internal class WordGroupConfiguration : IEntityTypeConfiguration<WordGroup>
    {
        public void Configure(EntityTypeBuilder<WordGroup> builder)
        {
            builder.HasKey(x => x.Id);


        }
    }
}
