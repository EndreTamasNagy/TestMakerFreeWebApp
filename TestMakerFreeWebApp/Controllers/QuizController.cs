using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestMakerFreeWebApp.ViewModels;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestMakerFreeWebApp.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        //Latest method which accepts GET request
        //GET api/quiz/latest
        [HttpGet("Latest/{num}")]
        public IActionResult Latest (int num = 10)
        {
            var sampleQuizzes = new List<QuizViewModel>();

            //add a first sample quiz
            sampleQuizzes.Add(new QuizViewModel()
            {
                Id = 1,
                Title = "which Shingeki No Kyojin character are you?",
                Description = "Anime-related personality test",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });

            //ad a bunch of other sample quizzes
            for(int i = 2; i <= num; i++)
            {
                sampleQuizzes.Add(new QuizViewModel()
                {
                    Id = i,
                    Title = String.Format("Sample Quiz {0}", i),
                    Description = "This is a sample quiz",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            //output the result in JSON format
            return new JsonResult(sampleQuizzes, new JsonSerializerSettings(){Formatting = Formatting.Indented});
        }

        //<summary>
        //GET api/quiz/ByTitle
        //Retrives the {num} quizzes stored by titel (a-z)
        //</summary>
        //<param name="num">the number of quizzes to retrive</param>
        //<returns>{num} Quizzes sorted by title</returns>
        [HttpGet("ByTitle/{num:int?}")]
        public IActionResult ByTitle(int num = 10)
        {
            var sampleQuizzes = ((JsonResult)Latest(num)).Value
                as List<QuizViewModel>;

            return new JsonResult(
                sampleQuizzes.OrderBy(t => t.Title), 
                new JsonSerializerSettings()
                { Formatting = Formatting.Indented });
        }

        //GET api/quiz/Random
        //summary: returns {num} quizzes in a random order
        //param: num - number of quizzes to retrive
        //return: {num} Quizzes sorted randomly
        [HttpGet("Random/{num:int?}")]
        public IActionResult Random(int num = 10)
        {
            //call the latest method
            var sampleQuizzes = ((JsonResult)Latest(num)).Value
                as List<QuizViewModel>;

            //return the elements
            return new JsonResult(
                sampleQuizzes.OrderBy(t => Guid.NewGuid()),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
    }
}
