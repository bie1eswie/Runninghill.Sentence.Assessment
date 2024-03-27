using AutoMapper;
using Runninghill.Sentence.Assessment.Application.Models;
using Runninghill.Sentence.Assessment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Domain.Models
{
    public class UserSentenceDTO
    {
        public string Text { get; set; } = string.Empty;

        public class UserSentenceProfile : Profile
        {
            public UserSentenceProfile()
            {
                CreateMap<UserSentence, UserSentenceDTO>()
                    .ReverseMap();
            }
        }
    }


}
