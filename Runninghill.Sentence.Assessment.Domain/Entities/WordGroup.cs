using Runninghill.Sentence.Assessment.Domain.Common;
using Runninghill.Sentence.Assessment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Domain.Entities
{
    public class WordGroup: BaseEntity<Guid>
    {

        public WordType WordType { get; set; }
        public string Description { get; set; } = string.Empty;
        public IList<WordItem> Items { get; private set; } = new List<WordItem>();
    }
}
