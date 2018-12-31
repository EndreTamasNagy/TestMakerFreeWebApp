﻿using System;
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
        #region RESTful conventions methods
        /// <summary>
        /// GET: api/quiz/{}id
        /// Retrives the Quiz with the given {id}
        /// </summary>
        /// <param name="id">The ID of an existing Quiz</param>
        /// <returns>The Quiz wiht the given {id}</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //create a sample quiz to match the given request
            var v = new QuizViewModel()
            {
                Id = id,
                Title = String.Format("Sample quiz with id {0}", id),
                Description = "Not a real quiz: it's just a sample!",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };

            //output the result in JSON format
            return new JsonResult(v, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Adds a new Quiz to the Database
        /// </summary>
        /// <param name="m">The QuizViewModel containing the data to insert</param>
        [HttpPut]
        public IActionResult Put(QuizViewModel m)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit the Quiz with the given {id}
        /// </summary>
        /// <param name="m">The QuizViewModel containing the data to update</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(QuizViewModel m)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the Quiz with the given {id} from the Database
        /// </summary>
        /// <param name="id">The ID of an existing Quiz</param>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Attribute-based routing methods
        /// <summary>
        /// GET: api/quiz/latest
        /// Retrives the {num} latest Quizzes
        /// </summary>
        /// <param name="num">the number of quizzes to retrive</param>
        /// <returns>the {nun} latest Quizzes</returns>
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
        #endregion

    
        /// <summary>
        /// GET api/quiz/ByTitle
        /// Retrives the {num} quizzes stored by titel (a-z)
        /// </summary>
        /// <param name="num">the number of quizzes to retrive</param>
        /// <returns>{num} Quizzes sorted by title</returns>
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
 
        /// <summary>
        ///GET: api/quiz/Random 
        /// returns {num} quizzes in a random order
        /// </summary>
        /// <param name="num">number of quizzes to retrive</param>
        /// <returns>{num} Quizzes sorted randomly</returns>
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
