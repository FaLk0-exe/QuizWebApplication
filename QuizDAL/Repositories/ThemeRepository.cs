using QuizDAL.EF;
using QuizDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizDAL.Repositories
{
    public class ThemeRepository : IThemeRepository
    {
        QuizContext _context;
        public ThemeRepository()
        {
            _context = new QuizContext();
        }
        public IQueryable<Theme> GetThemes()
        {
            return _context.Themes.AsQueryable();
        }
    }
}
