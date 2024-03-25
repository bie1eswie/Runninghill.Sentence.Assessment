using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Infrastructure.SeedData
{
    public static class WordItemData
    {
        private const string LIST_FILENAME = "words.json";
        public static WordItem FirstWordItem => ListWordItem[0];

        private static List<WordItem> _wordItemList = new List<WordItem>();
        public static List<WordItem> ListWordItem
        {
            get
            {
                if (_wordItemList.Count == 0)
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var strJson = assembly.GetResourceAsString(LIST_FILENAME);
                    var result = JsonSerializer.Deserialize<List<WordItem>>(strJson) ?? new List<WordItem>();
                    _wordItemList = result;
                }
                return _wordItemList;
            }
        }
    }
}
