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
        List<Question> _questions;
        Dictionary<int,int> _answers;
        int _currentQuestionIndex;
        bool _IsCompleted;
        bool _IsInitialized;
        public int ThemeId => _result.ThemeId;
        public bool IsCompleted => _IsCompleted;
        public bool IsInitialized => _IsInitialized;
        public List<Question> Questions => _questions;
        public Question CurrentQuestion
        {
            get
            {
                if(_questions is null)
                    throw new NullReferenceException("'questions' was null");
                return _questions.ElementAt(_currentQuestionIndex);
            }
        }

        public QuizService()
        {
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
                    _questions = _questionRepository.GetRandomQuestions(_result.ThemeId, count).ToList();
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
            foreach (var a in _answers)
                if (a.Value == answerId)
                {
                    _answers[_currentQuestionIndex] = answerId;
                    _currentQuestionIndex++;
                    return;
                }
                _answers.Add(_currentQuestionIndex, answerId);
                _currentQuestionIndex++;
        }
        
        public void SubmitResult()
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

        public void ClearService()
        {
            _answers.Clear();
            _questions.Clear();
            _result = null;
            _result = new Result { CorrectAnswersCount = 0 };
            _currentQuestionIndex = 0;
            _IsInitialized = false;
        }
    }
}
