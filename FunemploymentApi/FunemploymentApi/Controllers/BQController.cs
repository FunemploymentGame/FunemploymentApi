using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunemploymentApi.Data;
using FunemploymentApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FunemploymentApi.Controllers
{
    [Route("api/behavior")]
    [ApiController]
    public class BQController : ControllerBase
    {
        /// <summary>
        /// connect to the database for actions to use
        /// </summary>
        private readonly FunemploymentDBContext _context;

        public BQController(FunemploymentDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// gets all of the questions for the Behavioral table
        /// </summary>
        /// <returns>List of the questions from the table</returns>
        [HttpGet]
        public ActionResult<List<TechnicalQuestion>> GetAll()
        {     
            return Ok(_context.BehaviorQuestions.ToList());
        }

        /// <summary>
        /// finds and returns a specific behavioral question
        /// </summary>
        /// <param name="id">id of specific question</param>
        /// <returns>not found or the question</returns>
        [HttpGet("{id}", Name ="GetBQ")]
        public ActionResult<BehaviorQuestion> GetByID([FromRoute]int id)
        {
            var question = _context.BehaviorQuestions.Find(id);

            if(question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        /// <summary>
        /// asynchronously create a behavioral question and save it to the DB
        /// </summary>
        /// <param name="question">name of the new question</param>
        /// <returns> the new question</returns>
        [HttpPost]
        public async Task<IActionResult> Create ([FromBody]BehaviorQuestion question)
        {
            await _context.BehaviorQuestions.AddAsync(question);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetBQ", new { id = question.ID }, question);
        }

        /// <summary>
        /// updates a question if it exists, otherwise redirect to the Create method
        /// </summary>
        /// <param name="id">id of question you want to update</param>
        /// <param name="question">name of the question</param>
        /// <returns>no content or new question created</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody]BehaviorQuestion question)
        {
            var bq = _context.BehaviorQuestions.Find(id);
            if(bq == null)
            {
               return await Create(question);
            }

            bq.Content = question.Content;

            _context.BehaviorQuestions.Update(bq);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// finds a question by the ID and then removes it from the database
        /// </summary>
        /// <param name="id">the id of your</param>
        /// <returns>not found if it doesnt exist or No Content</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Destroy([FromRoute]int id)
        {
            var question = await _context.BehaviorQuestions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
             _context.BehaviorQuestions.Remove(question);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}