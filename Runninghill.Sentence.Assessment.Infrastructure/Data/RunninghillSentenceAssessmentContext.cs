using Microsoft.EntityFrameworkCore;
using Runninghill.Sentence.Assessment.Domain.Entities;
using System.Reflection;

namespace Runninghill.Sentence.Assessment.Infrastructure.Data
{
    public class RunninghillSentenceAssessmentContext: DbContext
    {
        public DbSet<WordItem> WordItems => Set<WordItem>();
        public DbSet<WordGroup> WordGroups => Set<WordGroup>();
        public DbSet<UserSentence> Sentences => Set<UserSentence>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public RunninghillSentenceAssessmentContext(DbContextOptions<RunninghillSentenceAssessmentContext> options): base(options)
        {
        }
    }
}
