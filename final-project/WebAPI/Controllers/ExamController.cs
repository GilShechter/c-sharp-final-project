using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly UserContext _dbContext;

        public ExamController(UserContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Exams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
        {
            if (_dbContext.Exams == null)
            {
                return NotFound();
            }
            return await _dbContext.Exams.Include("Questions")
                .Include("Questions.Answers")
                .Include("examUser")
                .ToListAsync();
        }

        // GET: api/Exams/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExam(int id)
        {
            if (_dbContext.Exams == null)
            {
                return NotFound();
            }
            var exam = await _dbContext.Exams
                .Include("Questions")
                .Include("Questions.Answers")
                .Include("examUser").FirstOrDefaultAsync(x => x.ExamId == id);

            if (exam == null)
            {
                return NotFound();
            }

            return exam;
        }

        // POST: api/Exams
        [HttpPost]
        public async Task<ActionResult<Exam>> PostExam(Exam exam)
        {
            _dbContext.Exams.Add(exam);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExam), new { id = exam.ExamId }, exam);
        }

        // DELETE: api/Exams/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            if (_dbContext.Exams == null)
            {
                return NotFound();
            }

            var exam = await _dbContext.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            _dbContext.Exams.Remove(exam);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Exams/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExam(int id, Exam exam)
        {
            if (id != exam.ExamId)
            {
                return BadRequest();
            }
            _dbContext.Entry(exam).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ExamExists(long id)
        {
            return (_dbContext.Exams?.Any(e => e.ExamId == id)).GetValueOrDefault();
        }

        /*        // GET: api/Exams/{QuestionsByExamID}
                [HttpGet("QuestionsByExamID")]
                public async Task<ActionResult<IEnumerable<Question>>> GetExamQuestions(int id)
                {
                    if (_dbContext.Exams == null)
                    {
                        return NotFound();
                    }
                    List<Question> results = await _dbContext.Questions.Include(q => q.Exam.Id == id).ToListAsync();
                    if (results.Count == 0)
                    {
                        return NotFound();
                    }
                    return results;
                }*/

        /*        // GET: api/Exams/{AnswersByQuestionID}
                [HttpGet("AnswersByQuestionID")]
                public async Task<ActionResult<IEnumerable<Answer>>> GetQuestionAnswers(int id)
                {
                    if (_dbContext == null)
                    {
                        return NotFound();
                    }
                    List<Answer> results = await _dbContext.Answers.Include(a => a.Question.Id == id).ToListAsync();
                    if (results.Count == 0)
                    {
                        return NotFound();
                    }
                    return results;
                }*/

    }

}
