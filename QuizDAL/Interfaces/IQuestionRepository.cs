using QuizDAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizDAL.Interfaces
{
    public interface IQuestionRepository
    {
        public IQueryable<Question> GetQuestions(int themeId);
        public IQueryable<Answer> GetAnswers(int questionId);
    }
}
