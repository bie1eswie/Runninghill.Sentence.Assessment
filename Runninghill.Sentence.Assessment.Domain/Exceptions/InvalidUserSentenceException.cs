using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Domain.Exceptions
{
    public class InvalidUserSentenceException : Exception
    {
        public InvalidUserSentenceException(string message) : base(message)
        {

        }
    }
}
