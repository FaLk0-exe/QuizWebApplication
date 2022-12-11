using QuizBLL.Interfaces;
using QuizDAL.EF;
using QuizDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizBLL.Services
{
    public class QuizService:IQuizService
    {
        ResultRepository _resultRepository;
        QuestionRepository _questionRepository;
        Result _result;
        int _themeId;
        List<Question> _questions;
        Dictionary<int,int> _answers;
        int _currentQuestionIndex;
        bool _IsCompleted;
        bool _IsInitialized;
        public Question CurrentQuestion
        {
            get
            {
                if(_questions is null)
                    throw new NullReferenceException("'questions' was null");
                try
                {
                    return _questions.ElementAt(_currentQuestionIndex);
                }
                catch(ArgumentOutOfRangeException)
                {
                    throw;
                }
            }
        }
        public QuizService()
        {
            _IsCompleted = false;
            _IsInitialized = false;
            _resultRepository = new ResultRepository();
            _questionRepository = new QuestionRepository();
            _answers = new Dictionary<int, int>();
            _result = new Result { CorrectAnswersCount = 0 };
            _currentQuestionIndex = 0;
        }

        public void InitializeQuestions(string userId,int themeId,int count)
        {
            if (!_IsInitialized)
            {
                if (count > _questionRepository.GetQuestions(themeId).Count())
                    throw new ArgumentException("'count' was greater then list size!");
                _result.UserId = userId;
                _result.ThemeId = themeId;
                try
                {
                    _questions = _questionRepository.GetRandomQuestions(_themeId, count).ToList();
                    _IsInitialized = true;
                }
                catch
                {
                    throw;
                }
            }
        }

        public void SelectAnswer(int answerId)
        {
            if (_questions is null)
                throw new NullReferenceException("'questions' was null");
            if (!_IsInitialized)
                throw new Exception("Quiz service was not initialized!");
            if(CurrentQuestion.Id==_questions.Last().Id)
            {
                if (!_IsCompleted)
                    SubmitResult();
                else
                    throw new Exception("Quiz was completed!");
            }
            _answers.Add(_currentQuestionIndex, answerId);
            _currentQuestionIndex++;
        }
        
        private void SubmitResult()
        {
            _result.CompleteDate = DateTime.Now;
            try
            {
                foreach(var v in _answers)
                {
                    if (_questions[v.Key].Answers.Any(answer => answer.Id == v.Value && answer.IsCorrect))
                        _result.CorrectAnswersCount++;
                }
                _resultRepository.SubmitResult(_result);
            }
            catch
            {
                throw new Exception("Problem occured at server side. Please, write to developer");
            }
        }
    }
}
