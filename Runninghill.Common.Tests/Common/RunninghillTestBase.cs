using AutoMoqCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Runninghill.Sentence.Assessment.Infrastructure.Data;
using Runninghill.Sentence.Assessment.Infrastructure.SeedData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Common.Tests.Common
{
    public class RunninghillTestBase
    {
        protected AutoMoqer _mocker;
        protected RunninghillSentenceAssessmentContext _runninghillSentenceAssessmentContext;

        [SetUp]
        public void BaseSetUp()
        {
            var serviceCollection = new ServiceCollection();
            _mocker = new AutoMoqer(new Config { MockBehavior = MockBehavior.Loose });
            serviceCollection.AddDbContext<RunninghillSentenceAssessmentContext>(c =>
            {
                c.EnableSensitiveDataLogging();
            });

            var serviceProvider = serviceCollection.BuildServiceProvider();

            _runninghillSentenceAssessmentContext = serviceProvider.GetRequiredService<RunninghillSentenceAssessmentContext>();
        }
        [TearDown]
        public void TearDown()
        {
            _runninghillSentenceAssessmentContext.Dispose();
        }

        public void SetUpDatabase()
        {
            var words = WordItemData.ListWordItem;
            var wordGroups = WordGroupData.ListWordGroup;
            var userSentences = UserSentenceData.ListUserSentence;
            _runninghillSentenceAssessmentContext.AddRange(words);
            _runninghillSentenceAssessmentContext.AddRange(wordGroups);
            _runninghillSentenceAssessmentContext.AddRange(userSentences);
            _runninghillSentenceAssessmentContext.SaveChanges();
            _mocker.SetInstance(_runninghillSentenceAssessmentContext);
        }
    }
}
