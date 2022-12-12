using Microsoft.EntityFrameworkCore;
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
        public Result GetResult(string userId,int themeId)
        {
            return _context.Results.Include(result=>result.Theme).ThenInclude(result=>result.Questions).FirstOrDefault(result => result.UserId == userId&& result.ThemeId == themeId);
        }

        public List<Result> GetResults()
        {
            return _context.Results.ToList();
        }

        public void SubmitResult(Result result)
        {
            try
            {
                if (result is null)
                    throw new NullReferenceException();
                _context.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
