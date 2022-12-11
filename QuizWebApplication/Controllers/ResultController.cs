using Microsoft.AspNetCore.Mvc;
using QuizDAL.Interfaces;
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
            if (resultRepository.GetResult(userId, themeId) == null)
                return NotFound();
            return View(resultRepository.GetResult(userId, themeId));

        }
    }
}
