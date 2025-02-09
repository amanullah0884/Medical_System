using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Medical_System.Model;

namespace Medical_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InstitutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institute>>> GetInstitutes()
        {
            return await _context.Institutes.ToListAsync();
        }

        // GET: api/Institutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Institute>> GetInstitute(int id)
        {
            var institute = await _context.Institutes.FindAsync(id);

            if (institute == null)
            {
                return NotFound();
            }

            return institute;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitute(int id, Institute institute)
        {
            if (id != institute.Id)
            {
                return BadRequest();
            }

            _context.Entry(institute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstituteExists(id))
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

        
        [HttpPost]
        public async Task<ActionResult<Institute>> PostInstitute(Institute institute)
        {
            _context.Institutes.Add(institute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstitute", new { id = institute.Id }, institute);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitute(int id)
        {
            var institute = await _context.Institutes.FindAsync(id);
            if (institute == null)
            {
                return NotFound();
            }

            _context.Institutes.Remove(institute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstituteExists(int id)
        {
            return _context.Institutes.Any(e => e.Id == id);
        }
    }
}
