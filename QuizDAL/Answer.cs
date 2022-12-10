using System;
using System.Collections.Generic;

#nullable disable

namespace QuizDAL
{
    public partial class Answer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
