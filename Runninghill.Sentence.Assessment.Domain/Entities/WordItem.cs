using Runninghill.Sentence.Assessment.Domain.Common;
using Runninghill.Sentence.Assessment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Domain.Entities
{
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Skip)]
    public class WordItem: BaseEntity<Guid>
    {
        public string Word {  get; set; } = string.Empty;
        public WordType WordType { get; set; }
        public WordGroup WordGroup { get; set; } = null!;
        public Guid WordGroupId { get; set; }
        public WordItem() 
        {
            Id = Guid.NewGuid();    
        }
    }
}
