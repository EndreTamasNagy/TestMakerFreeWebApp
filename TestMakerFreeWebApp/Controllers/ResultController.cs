using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestMakerFreeWebApp.ViewModels;
using System.Collections.Generic;



namespace TestMakerFreeWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ResultController : Controller
    {
        // GET: api/result/all
        [HttpGet("All/{quizid}")]
        public IActionResult All(int quizId)
        {
            //create result container list
            var sampleResult = new List<ResultViewModel>();

            //Add first sample result
            sampleResult.Add(new ResultViewModel()
            {
                Id=1,
                QuizId=quizId,
                Text="What do you value most in your life?",
                CreatedDate=DateTime.Now,
                LastModifiedDate=DateTime.Now,
            });

            //Add a bunch of sample results
            for(int i = 2; i <= 5; i++)
            {
                sampleResult.Add(new ResultViewModel()
                {
                    Id = i,
                    QuizId = quizId,
                    Text = String.Format("Sample Question {0}", i),
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            //return result in JSON format
            return new JsonResult(sampleResult, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
