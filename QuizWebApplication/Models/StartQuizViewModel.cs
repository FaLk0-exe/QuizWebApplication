using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebApplication.Models
{
    public class StartQuizViewModel
    {
        public int ThemeId { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrientedTime => Convert.ToInt32(Count * 30 / 60);

    }
}
