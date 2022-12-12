using QuizDAL.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizBLL.Interfaces
{
    public interface IQuizService
    {
        public bool IsCompleted { get; }
        public bool IsInitialized { get; }
        public void InitializeQuestions(string userId, int themeId, int count);
        public void SelectAnswer(int answerId);
        public Question CurrentQuestion { get; }
        public List<Question> Questions { get; }
        public int ThemeId { get; }
        public void SubmitResult();
        public void ClearService();
    }
}
