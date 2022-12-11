using Microsoft.AspNetCore.Mvc;
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
            return View(themeRepository.GetThemes());
        }

        public IActionResult Start([FromServices] IQuestionRepository questionRepository, int themeId)
        {
            ViewData["count"] = Convert.ToInt32(questionRepository.GetQuestions(themeId).Count()/2);
            ViewData["orientedTime"] = Convert.ToInt32(Convert.ToInt32(ViewData["count"]) * 30/ 60);
            return View();
        }
    }
}
