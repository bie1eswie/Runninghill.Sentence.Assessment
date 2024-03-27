using Runninghill.Sentence.Assessment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Domain.Interface.Repositories
{
    public interface IWordGroupRepository
    {
        Task<List<WordGroup>> GetAllWordsGroupAsync();
    }
}
