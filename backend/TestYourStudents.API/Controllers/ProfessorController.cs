using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestYourStudents.API.Requests;
using TestYourStudents.Core.Entities;
using TestYourStudents.EF;

namespace TestYourStudents.API.Controllers
{
    [ApiController]
    [Route("/api/professor")]
    public class ProfessorController: ControllerBase
    {
        private readonly TestYourStudentsDbContext _context;

        public ProfessorController(TestYourStudentsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var professors = await _context.Professor.ToListAsync();
            return Ok(professors);
        }

        [HttpPost]
        public async Task<IActionResult> AddProfessor([FromBody] ProfessorRequest professor)
        {
            var professors = await _context.Professor.Where(p => p.Phone.Equals(professor.Phone)).ToListAsync();

            if (professors.Count >= 1)
                return BadRequest("The professor with phone number " + professor.Phone + " already exist!");

            var newProfessor = new Professor()
            {
                Firstname = professor.Firstname,
                Lastname = professor.Lastname,
                Phone = professor.Phone
            };

            await _context.Professor.AddAsync(newProfessor);
            await _context.SaveChangesAsync();

            return Ok(newProfessor);
        }
        
        [HttpPut]
        public async Task<IActionResult> EditProfessor([FromBody] Professor request)
        {
            var professors = await _context.Professor.Where(p => p.Phone.Equals(request.Phone) && p.Id != request.Id).ToListAsync();
            var professor = await _context.Professor.Where(p => p.Id.Equals(request.Id)).FirstOrDefaultAsync();

            if (professor == null)
                return BadRequest("Provided professor doesnt exist!");

            if (professors.Count >= 1)
                return BadRequest("The professor with phone number " + professor.Phone + " already exist!");

            professor.Firstname = request.Firstname;
            professor.Lastname = request.Lastname;
            professor.Phone = request.Phone;
            
            await _context.SaveChangesAsync();

            return Ok(professor);
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteProfessor([FromQuery] int id)
        {
            var professors = await _context.Professor.Where(p => p.Id.Equals(id)).ToListAsync();

            if (professors.Count == 0)
                return BadRequest("Provided professor doesnt exist!");


            var professor = professors.FirstOrDefault(p => p.Id.Equals(id));

            professors.Remove(professor);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}