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
        #region RESTful conventions methods
        /// <summary>
        /// Retrives the Answer with the given {id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Content("Not implemented (yet)!");
        }

        /// <summary>
        /// Adds a new Answer to the Database
        /// </summary>
        /// <param name="m">The AnswerViewModel containing the data to insert</param>
        [HttpPut]
        public IActionResult Put(AnswerViewModel m)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit the Answer with the given {id}
        /// </summary>
        /// <param name="m">The AnswerViewModel containing the data to update</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(AnswerViewModel m)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the Answer with the given {id} from the Database
        /// </summary>
        /// <param name="id">The ID of an existing Answer</param>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
        #endregion


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
