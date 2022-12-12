using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebApplication.Models
{
    public class ResultViewModel
    {
        public int CorrectAnswersCount { get; set; }
        public string ThemeName { get; set; }
        public DateTime CompleteDate { get; set; }
        public int TotalAnswersCount { get; set; }
    }
}
