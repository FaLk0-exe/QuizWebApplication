using Microsoft.AspNetCore.Mvc;
using QuizBLL.Interfaces;
using QuizDAL.EF;
using QuizDAL.Interfaces;
using QuizWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebApplication.Controllers
{
    public class QuestionController : Controller
    {
        public QuestionController()
        {

        }

        private string UserId{ get => User.Claims.First(claim => claim.Value.Contains("@")).Value; }

        public IActionResult Start([FromServices] IQuizService quizService, StartQuizViewModel model)
        {
            var email = UserId;
            quizService.InitializeQuestions(email, model.ThemeId, model.Count);
            return Redirect(Url.ActionLink(action: "Question", controller: "Question",values:new {AnswerId = -1}));
        }

        public IActionResult Question([FromServices] IResultRepository resultRepository,
            [FromServices] IQuestionRepository questionRepository,
            [FromServices] IQuizService quizService, int AnswerId)
        {
            QuestionViewModel questionViewModel = new QuestionViewModel();
            if (!quizService.IsCompleted)
            {
                if (AnswerId!= -1)
                    quizService.SelectAnswer(AnswerId);
                try
                {
                    questionViewModel.Question = quizService.CurrentQuestion;
                    if (questionViewModel.Question.Id == quizService.Questions.Last().Id)
                        ViewData["buttonDescription"] = "Finish";
                    else
                        ViewData["buttonDescription"] = "Next";
                }
                catch (ArgumentOutOfRangeException)
                {
                    quizService.SubmitResult();
                    quizService.ClearService();
                    return Redirect(Url.ActionLink(controller: "Result", action: "Result", values: new
                    {
                        themeId = quizService.ThemeId,
                        UserId = UserId
                    }));
                }
                questionViewModel.Answers = questionRepository.GetAnswers(questionViewModel.Question.Id);
                questionViewModel.AnswerId = -1;
                return View(questionViewModel);
            }
            else
            {
                return Redirect(Url.ActionLink(controller: "Result", action: "Result", values: new
                {
                    themeId = questionRepository.GetQuestion(questionViewModel.AnswerId),
                    userId = User.Claims.First(claim => claim.Value.Contains("@")).Value
                }));
            }
        }
    }
}
