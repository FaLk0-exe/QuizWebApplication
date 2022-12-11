using System;
using System.Collections.Generic;
using System.Text;

namespace QuizBLL.Interfaces
{
    public interface IQuizService
    {
        public void InitializeQuestions(string userId, int themeId, int count);
        public void SelectAnswer(int answerId);
   
    }
}
