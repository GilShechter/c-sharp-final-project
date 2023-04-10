using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamUsersController : ControllerBase
    {
        private readonly UserContext _dbContext;

        public ExamUsersController(UserContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/ExamUsers/id
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ExamUser>>> GetExamUsers(int id)
        {
            if (_dbContext.Exams == null)
            {
                return NotFound();
            }
            return await _dbContext.ExamUsers.Where(x => x.ExamId == id).ToListAsync();
        }

        // POST: api/ExamUsers
        [HttpPost]
        public async Task<ActionResult<ExamUser>> PostExam(ExamUser examUser)
        {
            _dbContext.ExamUsers.Add(examUser);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExamUsers), new { id = examUser.Id }, examUser);
        }
    }
}
