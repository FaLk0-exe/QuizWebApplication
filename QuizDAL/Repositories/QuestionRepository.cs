using QuizDAL.EF;
using QuizDAL.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace QuizDAL.Repositories
{
    class QuestionRepository : IQuestionRepository
    {
        QuizContext _quizContext;
        public QuestionRepository()
        {
            _quizContext = new QuizContext();
        }
        public IQueryable<Answer> GetAnswers(int questionId)
        {
            return _quizContext.Answers.Where(answer=>answer.QuestionId==questionId);
        }

        public IQueryable<Question> GetQuestions(int themeId)
        {
            return _quizContext.Questions.Where(question=>question.ThemeId==themeId);
        }
    }
}
