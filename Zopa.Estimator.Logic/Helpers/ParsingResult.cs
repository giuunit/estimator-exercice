using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zopa.Estimator.Logic.Helpers
{
    public class ParsingResult<T> where T : IParsedResult, new()
    {
        public T Result { get; set; }
        public List<string> Warnings = new List<string>();

        public ParsingResult()
        {

        }
    }
}
