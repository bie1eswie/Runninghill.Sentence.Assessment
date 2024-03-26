using AutoMapper;
using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Application.Models
{
    public class WordGroupDTO
    {
        public WordType WordType { get; set; }
        public string Description { get; set; } = string.Empty;
        public IList<WordItemDTO> Items { get; private set; } = new List<WordItemDTO>();
        public class WordGroupProfile : Profile
        {
            public WordGroupProfile()
            {
                CreateMap<WordGroup, WordGroupDTO>()
                    .ReverseMap();
            }
        }
    }
}
