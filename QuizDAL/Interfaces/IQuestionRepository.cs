using QuizDAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizDAL.Interfaces
{
    public interface IQuestionRepository
    {
        public List<Question> GetQuestions(int themeId);
        public List<Answer> GetAnswers(int questionId);
        public List<Question> GetRandomQuestions(int themeId,int count);
        public Question GetQuestion(int id);
        public Answer GetAnswer(int id);
    }
}
