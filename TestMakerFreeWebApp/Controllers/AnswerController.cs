using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestMakerFreeWebApp.ViewModels;
using System.Collections.Generic;



namespace TestMakerFreeWebApp.Controllers
{
    [Route("api/[controller]")]
    public class AnswerController : Controller
    {
        // GET: api/answer/all
        public IActionResult All(int questionId)
        {
            var sampleAnswers = new List<AnswerViewModel>();

            //Add first sample answer
            //I have to expand the list with the object, which should be instanciated
            sampleAnswers.Add(new AnswerViewModel()
            {
                Id = 1,
                QuestionId = questionId,
                Text="Friends and Family",
                CreatedDate=DateTime.Now,
                LastModifiedDate=DateTime.Now
            });

            //Add a bunch of other answers
            for(int i = 2; i <= 5; i++)
            {
                sampleAnswers.Add(new AnswerViewModel()
                {
                    Id=i,
                    QuestionId =questionId,
                    Text=String.Format("Sample Answer {0}",i),
                    CreatedDate=DateTime.Now,
                    LastModifiedDate=DateTime.Now
                });
            }

            //return the Json result
            return new JsonResult(sampleAnswers, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
