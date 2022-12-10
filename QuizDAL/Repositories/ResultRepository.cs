using QuizDAL.EF;
using QuizDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizDAL.Repositories
{
    public class ResultRepository : IResultRepository
    {
        QuizContext _context;
        public ResultRepository()
        {
            _context = new QuizContext();
        }
        public Result GetResult(string userId)
        {
            return _context.Results.FirstOrDefault(result => result.UserId == userId);
        }

        public IEnumerable<Result> GetResults()
        {
            return _context.Results.AsEnumerable();
        }

        public bool SubmitResult(Result result)
        {
            try
            {
                if (result is null)
                    throw new NullReferenceException();
                _context.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
