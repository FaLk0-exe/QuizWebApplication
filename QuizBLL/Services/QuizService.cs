using QuizBLL.Interfaces;
using QuizDAL.EF;
using QuizDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizBLL.Services
{
    class QuizService:IQuizService
    {
        ResultRepository _resultRepository;
        QuestionRepository _questionRepository;
        Result _result;
        int _themeId;
        List<Question> _questions;
        int _currentQuestionIndex;
        bool _IsCompleted;
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
        public QuizService(string userId,int themeId,int count)
        {
            _IsCompleted = false;
            _themeId = themeId;
            _resultRepository = new ResultRepository();
            _questionRepository = new QuestionRepository();
            _result = new Result { UserId = userId, CorrectAnswersCount = 0,ThemeId=_themeId };
            _currentQuestionIndex = 0;
        }

        public void InitializeQuestions(int count)
        {
            try
            {
                _questions = _questionRepository.GetRandomQuestions(_themeId, count).ToList();
            }
            catch
            {
                throw;
            }
        }

        public void SelectAnswer(int answerId)
        {
            if (_questions is null)
                throw new NullReferenceException("'questions' was null");
            try
            {
                if (_questionRepository.GetAnswers(CurrentQuestion.Id).First(answer => answer.Id == answerId).IsCorrect)
                {
                    _result.CorrectAnswersCount++;
                }
                _currentQuestionIndex++;
            }
            catch(NullReferenceException)
            {
                throw;
            }
            catch(ArgumentOutOfRangeException)
            {
                if (!_IsCompleted)
                    SubmitResult();
                else
                    throw new Exception("Quiz was completed!");
            }
        }
        
        private void SubmitResult()
        {
            _result.CompleteDate = DateTime.Now;
            try
            {
                _resultRepository.SubmitResult(_result);
            }
            catch
            {
                throw new Exception("Problem occured at server side. Please, write to developer");
            }
        }
    }
}
