using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunemploymentApi.Data;
using Microsoft.AspNetCore.Mvc;
using FunemploymentApi.Models;

namespace FunemploymentApi.Controllers
{
    [Route("api/technical")]
    [ApiController]
    public class TQController : ControllerBase
    {
        private readonly FunemploymentDBContext _context;

        public TQController(FunemploymentDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// read all of the technical questions from their table in the DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<TechnicalQuestion>> GetAll()
        {
            return Ok(_context.TechnicalQuestions.ToList());
        }

        /// <summary>
        /// read specific question based on ID if able
        /// </summary>
        /// <param name="id">question you're searching for</param>
        /// <returns>not found or the specific question</returns>
        [HttpGet("{id}", Name = "GetTQ")]
        public ActionResult<TechnicalQuestion> GetByID(int id)
        {
            var question = _context.TechnicalQuestions.Find(id);

            if( question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        /// <summary>
        /// asynchronously add a new question to the Technical questions database
        /// </summary>
        /// <param name="question">question being added</param>
        /// <returns>new question</returns>
        [HttpPost]
        public async Task<IActionResult> Create (TechnicalQuestion question)
        {
            await _context.TechnicalQuestions.AddAsync(question);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetTQ", new { id = question.ID }, question);
        }

        /// <summary>
        /// find question by id and then update, if no id then make a new question
        /// IMPORTANT that this only appears when coming from a specific questions page with its ID
        /// </summary>
        /// <param name="id">id of question you wanna update</param>
        /// <param name="question">question name</param>
        /// <returns>create page if no id is found or no content if update is successful</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TechnicalQuestion question)
        {
         

            var tq = await _context.TechnicalQuestions.FindAsync(id);
            if(tq == null)
            {
                return await Create(question);
            }

            tq.ProblemDomain = question.ProblemDomain;
            tq.Difficulty = question.Difficulty;
            tq.Input = question.Input;
            tq.Output = question.Output;

            _context.TechnicalQuestions.Update(tq);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// find question by ID and then delete it if it exists
        /// </summary>
        /// <param name="id">id of the question you want to delete</param>
        /// <returns>not found if id doesnt exists or No content if its successful</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var question = await _context.TechnicalQuestions.FindAsync(id);
            if(question == null)
            {
                return NotFound();
            }

            _context.TechnicalQuestions.Remove(question);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}