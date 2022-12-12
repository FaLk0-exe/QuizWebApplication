using Microsoft.AspNetCore.Mvc;
using QuizDAL.Interfaces;
using QuizWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebApplication.Controllers
{
    public class ResultController:Controller
    {
        public ResultController()
        {

        }
        
        public IActionResult Result([FromServices] IResultRepository resultRepository, int themeId,string userId)
        {
            var result = resultRepository.GetResult(userId, themeId);
            if (result == null)
                return NotFound();
            var resultViewModel = new ResultViewModel
            {
                CorrectAnswersCount = result.CorrectAnswersCount,
                CompleteDate = result.CompleteDate,
                ThemeName = result.Theme.Name,
                TotalAnswersCount = result.Theme.Questions.Count()
            };
            return View(resultViewModel);

        }
    }
}
