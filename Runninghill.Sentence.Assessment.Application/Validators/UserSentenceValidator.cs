using FluentValidation;
using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Application.Validators
{
    public class UserSentenceValidator: AbstractValidator<UserSentenceDTO>
    {
        public UserSentenceValidator() 
        {
            RuleFor(v => v.Text)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
