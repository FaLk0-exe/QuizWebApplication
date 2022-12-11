using QuizDAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizDAL.Interfaces
{
    public interface IThemeRepository
    {
        public List<Theme> GetThemes();
        public Theme GetTheme(int id);
    }
}
