using QuizDAL.EF;
using QuizDAL.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace QuizDAL.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        QuizContext _quizContext;
        public QuestionRepository()
        {
            _quizContext = new QuizContext();
        }
        public IEnumerable<Answer> GetAnswers(int questionId)
        {
            return _quizContext.Answers.Where(answer=>answer.QuestionId==questionId).AsEnumerable();
        }

        public IEnumerable<Question> GetQuestions(int themeId)
        {
            return _quizContext.Questions.Where(question=>question.ThemeId==themeId).AsEnumerable();
        }

        public IEnumerable<Question> GetRandomQuestions(int themeId, int count)
        {
            Random random=new Random();
            var questions = GetQuestions(themeId);
            if (questions.Count() < count)
                throw new ArgumentException("'count' was greater then question list size!");
            return questions.OrderBy(question => random.Next()).Take(count);
        }
    }
}
