using MedUnify.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MedUnify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProgressNotesController : ControllerBase
    {
        private readonly DataContext _context;

        public ProgressNotesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ProgressNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgressNote>>> GetProgressNotes()
        {
            return await _context.ProgressNotes.ToListAsync();
        }

        // GET: api/ProgressNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgressNote>> GetProgressNote(int id)
        {
            var progressNote = await _context.ProgressNotes.FindAsync(id);

            if (progressNote == null)
            {
                return NotFound();
            }

            return progressNote;
        }

        // POST: api/ProgressNotes
        [HttpPost]
        public async Task<ActionResult<ProgressNote>> AddProgressNote(ProgressNote progressNote)
        {
            _context.ProgressNotes.Add(progressNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProgressNote), new { id = progressNote.ProgressNoteId }, progressNote);
        }

        // PUT: api/ProgressNotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgressNote(int id, ProgressNote progressNote)
        {
            if (id != progressNote.ProgressNoteId)
            {
                return BadRequest();
            }

            _context.Entry(progressNote).State = (System.Data.Entity.EntityState)EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgressNoteExists(id))
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

        // DELETE: api/ProgressNotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgressNote(int id)
        {
            var progressNote = await _context.ProgressNotes.FindAsync(id);
            if (progressNote == null)
            {
                return NotFound();
            }

            _context.ProgressNotes.Remove(progressNote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgressNoteExists(int id)
        {
            return _context.ProgressNotes.Any(p => p.ProgressNoteId == id);
        }
    }
}
