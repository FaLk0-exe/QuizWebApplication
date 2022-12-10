using System;
using System.Collections.Generic;

#nullable disable

namespace QuizDAL
{
    public partial class Theme
    {
        public Theme()
        {
            Questions = new HashSet<Question>();
            Results = new HashSet<Result>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
