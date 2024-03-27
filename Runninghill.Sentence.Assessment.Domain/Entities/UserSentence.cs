using Runninghill.Sentence.Assessment.Domain.Common;

namespace Runninghill.Sentence.Assessment.Domain.Entities
{
    public class UserSentence: BaseEntity<Guid>
    {
        public string Text {  get; set; } = string.Empty;
        public DateTime? CreatedOn { get; set; }
    }
}
