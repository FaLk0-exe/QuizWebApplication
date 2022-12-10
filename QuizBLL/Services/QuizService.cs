using QuizDAL.EF;
using QuizDAL.Repositories;

namespace QuizBLL.Services
{
    class QuizService
    {
        ResultRepository _resultRepository;
        QuestionRepository _questionRepository;
        Result result;
        int _themeId;
        public QuizService(string userId,int themeId)
        {
            _themeId = themeId;
            _resultRepository = new ResultRepository();
            _questionRepository = new QuestionRepository();
            result = new Result { UserId = userId, CorrectAnswersCount = 0 };
        }

        public void SelectAnswer(int answerId)
        {
            _questionRepository.GetQuestions(_themeId).;
        }
        
    }
}
