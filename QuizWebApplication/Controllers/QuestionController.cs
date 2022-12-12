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

        private IActionResult RedirectToResult(IQuizService quizService)
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect(Url.ActionLink(action: "Index", controller: "Home"));
            return Redirect(Url.ActionLink(controller: "Result", action: "Result", values: new
            {
                themeId = quizService.ThemeId,
                userId = UserId
            }));
        }

        private string UserId{ get => User.Claims.First(claim => claim.Value.Contains("@")).Value; }

        public IActionResult Start([FromServices] IQuizService quizService, StartQuizViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect(Url.ActionLink(action: "Index", controller: "Home"));
            quizService.ClearService();
            var email = UserId;
            quizService.InitializeQuestions(email, model.ThemeId, model.Count);
            return Redirect(Url.ActionLink(action: "Question", controller: "Question",values:new {AnswerId = -1}));
        }

        public IActionResult Question([FromServices] IResultRepository resultRepository,[FromServices] IQuestionRepository questionRepository,[FromServices] IQuizService quizService, int AnswerId)
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect(Url.ActionLink(action: "Index", controller: "Home"));
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
                    return RedirectToResult(quizService);
                }
                questionViewModel.Answers = questionRepository.GetAnswers(questionViewModel.Question.Id);
                questionViewModel.AnswerId = -1;
                return View(questionViewModel);
            }
            return RedirectToResult(quizService);
        }
    }
}
