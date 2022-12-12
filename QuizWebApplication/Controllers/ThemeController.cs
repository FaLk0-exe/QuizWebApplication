using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizDAL.EF;
using QuizDAL.Interfaces;
using QuizWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebApplication.Controllers
{
    public class ThemeController:Controller
    {
        public ThemeController()
        {

        }
        public IActionResult Themes([FromServices] IThemeRepository themeRepository)
        {
            if (User.Identity.IsAuthenticated)
                return View(themeRepository.GetThemes());
            else
                return Redirect(Url.ActionLink(action: "Index", controller: "Home"));
        }

        public IActionResult Start([FromServices] IResultRepository resultRepository, [FromServices] IThemeRepository themeRepository, [FromServices] IQuestionRepository questionRepository, int themeId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var email = User.Claims.First(claim => claim.Value.Contains("@")).Value;
                if (resultRepository.GetResult(email, themeId) != null)
                    return Redirect(Url.ActionLink(controller: "Result", action: "Result", values: new { userId = email, themeId = themeId }));
                Theme theme;
                try
                {
                    theme = themeRepository.GetTheme(themeId);
                    if (theme is null)
                        throw new NullReferenceException(nameof(theme));
                }
                catch (NullReferenceException)
                {
                    return NotFound();
                }
                return View(new StartQuizViewModel
                {
                    ThemeId = theme.Id,
                    Count = questionRepository.GetQuestions(themeId).Count()/2,
                    Description = theme.ThemeDescription,
                    Name = theme.Name
                });
            }
            return Redirect(Url.ActionLink(action: "Index", controller: "Home"));
        }
    }
}
