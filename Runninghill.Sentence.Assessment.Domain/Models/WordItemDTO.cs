using AutoMapper;
using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Application.Models
{
    public class WordItemDTO
    {
        public string Word { get; set; } = string.Empty;
        public WordType WordType { get; set; }
        public Guid WordGroupId { get; set; }

        public class WordItemProfile: Profile
        {
            public WordItemProfile()
            {
                CreateMap<WordItem, WordItemDTO>()
                    .ReverseMap();
            }
        }
    }
}
