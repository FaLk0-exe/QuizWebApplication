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

        public Theme GetTheme(int id)
        {
            return _context.Themes.FirstOrDefault(theme => theme.Id == id);
        }

        public IEnumerable<Theme> GetThemes()
        {
            return _context.Themes.AsEnumerable();
        }
    }
}
