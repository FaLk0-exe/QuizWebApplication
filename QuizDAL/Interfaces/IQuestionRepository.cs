using QuizDAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizDAL.Interfaces
{
    public interface IQuestionRepository
    {
        public IEnumerable<Question> GetQuestions(int themeId);
        public IEnumerable<Answer> GetAnswers(int questionId);
        public IEnumerable<Question> GetRandomQuestions(int themeId,int count);
    }
}
