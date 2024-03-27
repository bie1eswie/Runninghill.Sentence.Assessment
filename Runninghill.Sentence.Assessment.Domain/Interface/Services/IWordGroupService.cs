using Runninghill.Sentence.Assessment.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Domain.Interface.Services
{
    public interface IWordGroupService
    {
        Task<List<WordGroupDTO>> GetWordGroups();
    }
}
