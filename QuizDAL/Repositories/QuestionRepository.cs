using QuizDAL.EF;
using QuizDAL.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace QuizDAL.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        QuizContext _quizContext;
        public QuestionRepository()
        {
            _quizContext = new QuizContext();
        }

        public Answer GetAnswer(int id)
        {
            return _quizContext.Answers.Include(a => a.Question).ThenInclude(a => a.Theme).FirstOrDefault(a => a.Id == id);
        }

        public List<Answer> GetAnswers(int questionId)
        {
            return _quizContext.Answers.Include(q => q.Question).Where(answer=>answer.QuestionId==questionId).ToList();
        }

        public Question GetQuestion(int id)
        {
            return _quizContext.Questions.FirstOrDefault(question => question.Id == id);
        }

        public List<Question> GetQuestions(int themeId)
        {
            return _quizContext.Questions.Include(q=>q.Answers).Include(q=>q.Theme).Where(question=>question.ThemeId==themeId).ToList();
        }

        public List<Question> GetRandomQuestions(int themeId, int count)
        {
            Random random=new Random();
            var questions = GetQuestions(themeId);
            if (questions.Count() < count)
                throw new ArgumentException("'count' was greater then question list size!");
            return questions.OrderBy(question => random.Next()).Take(count).ToList();
        }
    }
}
