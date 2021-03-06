﻿using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestMakerFreeWebApp.ViewModels;
using System.Collections.Generic;



namespace TestMakerFreeWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ResultController : Controller
    {
        #region RESTful conventions methods
        /// <summary>
        /// Retrives the Result with the given {id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Content("Not implemented (yet)!");
        }

        /// <summary>
        /// Adds a new Result to the Database
        /// </summary>
        /// <param name="m">The ResultViewModel containing the data to insert</param>
        [HttpPut]
        public IActionResult Put(ResultViewModel m)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit the Result with the given {id}
        /// </summary>
        /// <param name="m">The ResultViewModel containing the data to update</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ResultViewModel m)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the Result with the given {id} from the Database
        /// </summary>
        /// <param name="id">The ID of an existing Result</param>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

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
