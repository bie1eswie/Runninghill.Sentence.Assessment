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
    public class UserSentenceData
    {
        private const string LIST_FILENAME = "user-sentence.json";
        public static UserSentence FirstUserSentence => ListUserSentence[0];

        private static List<UserSentence> _userSentenceList = new List<UserSentence>();
        public static List<UserSentence> ListUserSentence
        {
            get
            {
                if (_userSentenceList.Count == 0)
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var strJson = assembly.GetResourceAsString(LIST_FILENAME);
                    var result = JsonSerializer.Deserialize<List<UserSentence>>(strJson) ?? new List<UserSentence>();
                    _userSentenceList = result;
                }
                return _userSentenceList;
            }
        }
    }
}
