using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Infrastructure.SeedData
{
    public static class WordGroupData
    {
        private const string LIST_FILENAME = "word-groups.json";
        public static WordGroup FirstWordGroup => ListWordGroup[0];

        private static List<WordGroup> _wordGroupList = new List<WordGroup>();
        public static List<WordGroup> ListWordGroup
        {
            get
            {
                if (_wordGroupList.Count == 0)
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var strJson = assembly.GetResourceAsString(LIST_FILENAME);
                    var result = JsonSerializer.Deserialize<List<WordGroup>>(strJson) ?? new List<WordGroup>();
                    _wordGroupList = result;
                }
                return _wordGroupList;
            }
        }
    }
}
