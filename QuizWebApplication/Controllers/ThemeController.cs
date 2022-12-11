using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizDAL.EF;
using QuizDAL.Interfaces;
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

        public IActionResult Start([FromServices] IThemeRepository themeRepository,
            [FromServices] IQuestionRepository questionRepository, int themeId)
        {
            if (User.Identity.IsAuthenticated)
            {
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
                ViewData["name"] = theme.Name;
                ViewData["description"] = theme.ThemeDescription;
                ViewData["count"] = Convert.ToInt32(questionRepository.GetQuestions(themeId).Count() / 2);
                ViewData["orientedTime"] = Convert.ToInt32(Convert.ToInt32(ViewData["count"]) * 30 / 60);
                return View();
            }
            else
            {
                return Redirect(Url.ActionLink(action: "Index", controller: "Home"));
            }
        }
    }
}
