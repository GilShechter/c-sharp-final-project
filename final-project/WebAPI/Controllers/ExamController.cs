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
            var curr_exam = _dbContext.Exams.Where(x => x.Name == exam.Name).ToList().FirstOrDefault();
            List<WebAPI.Models.Question> q_list = new List<Question>();
            var old_q_list = _dbContext.Questions.Include("Answers").Where(x => x.ExamID == curr_exam.ExamId).ToList();
            foreach(Question q in old_q_list)
            {
                _dbContext.Questions.Remove(q);
            }
            foreach (Question q in exam.Questions)
            {
                WebAPI.Models.Question curr_question = new Question
                {
                    Content = q.Content,
                    ImgName = q.ImgName,
                    ImgPath = q.ImgPath,
                    ChosenAnswer = q.ChosenAnswer,
                    ExamID = q.ExamID                  
                };
                curr_question.Answers = q.Answers;
                q_list.Add(curr_question);
            }
            curr_exam.Questions = q_list;

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


    }

}
