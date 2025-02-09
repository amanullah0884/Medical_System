using Medical_System.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medical_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationsController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public ConsultationsController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consultation>>>GetConsultation()
        {
            return await _context.Consultations
                .Include(d => d.Doctor)
                .Include(d =>d.Patient)
                .ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Consultation>>GetConsultation(int id)
        {
            var consultation = await _context.Consultations
                .Include(d => d.Doctor)
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(d =>d.Id ==id);
            if (consultation == null)
            {
                return NotFound();
            }
            return Ok(consultation);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConsultation(int id, Consultation consultation)
        {
            if (id != consultation.Id)
            {
                return BadRequest();
            }

            _context.Entry(consultation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultatonExists(id))
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

        private bool ConsultatonExists(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<Consultation>> CreateConsultation(Consultation consultation)
        {
            _context.Consultations.Add(consultation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsultation", new { id = consultation.Id }, consultation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultation(int id)
        {
            var consul = await _context.Consultations.FindAsync(id);
            if (consul == null)
            {
                return NotFound();
            }

            _context.Consultations.Remove(consul);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
