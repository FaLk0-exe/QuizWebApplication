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

        public IActionResult Start([FromServices] IQuizService quizService, StartQuizViewModel model)
        {
            var email = User.Claims.First(claim => claim.Value.Contains("@")).Value;
            quizService.InitializeQuestions(email, model.ThemeId, model.Count);
            var question = quizService.CurrentQuestion;
            return Redirect(Url.ActionLink(action: "Question", controller: "Question", question));
        }

        public IActionResult Question([FromServices] IQuestionRepository questionRepository, [FromServices] IQuizService quizService, Question question, int? answerId)
        {
            if (!quizService.IsCompleted)
            {
                if (answerId != null)
                    quizService.SelectAnswer((int)answerId);
                if (question.Id == quizService.Questions.Last().Id)
                    ViewData["buttonDescription"] = "Finish";
                else
                    ViewData["buttonDescription"] = "Next";
                try
                {
                    question = quizService.CurrentQuestion;
                }
                catch (ArgumentOutOfRangeException)
                {
                    quizService.SubmitResult();
                    return Redirect(Url.ActionLink(controller: "Result", action: "Result", values: new
                    {
                        themeId = questionRepository.GetQuestion((int)answerId),
                        userId = User.Claims.First(claim => claim.Value.Contains("@")).Value
                    }));
                }
                var answers = questionRepository.GetAnswers(question.Id);
                return View(new QuestionViewModel { Answers = answers.ToList(), Question = question, AnswerId = -1 });
            }
            else
            {
                return Redirect(Url.ActionLink(controller: "Result", action: "Result", values: new
                {
                    themeId = questionRepository.GetQuestion((int)answerId),
                    userId = User.Claims.First(claim => claim.Value.Contains("@")).Value
                }));
            }
        }
    }
}
