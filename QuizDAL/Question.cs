using System;
using System.Collections.Generic;

#nullable disable

namespace QuizDAL
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ThemeId { get; set; }

        public virtual Theme Theme { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
