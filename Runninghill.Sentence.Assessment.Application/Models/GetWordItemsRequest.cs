using Runninghill.Sentence.Assessment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Application.Models
{
    public class GetWordItemsRequest
    {
        public WordType WordType { get; set; }
    }
}
