using Microsoft.AspNetCore.Mvc;
using QuizDAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebApplication.Models
{
    public class QuestionViewModel
    {
        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }
        public int AnswerId { get; set; }
    }
}
