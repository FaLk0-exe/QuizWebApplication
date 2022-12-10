using QuizDAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizDAL.Interfaces
{
    public interface IResultRepository
    {
        public Result GetResult(string userId);
        public IEnumerable<Result> GetResults();
        public bool SubmitResult(Result result);
    }
}
