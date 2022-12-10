using System;
using System.Collections.Generic;

#nullable disable

namespace QuizDAL
{
    public partial class Result
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime CompleteDate { get; set; }
        public int ThemeId { get; set; }
        public int CorrectAnswersCount { get; set; }

        public virtual Theme Theme { get; set; }
    }
}
