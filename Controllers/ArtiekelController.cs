using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace jimid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtiekelController : ControllerBase
    {
        private readonly MyContext _context;

        public ArtiekelController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Artiekel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artiekel>>> GetArtiekel()
        {
            return await _context.Artiekel.ToListAsync();
        }

        // GET: api/Artiekel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artiekel>> GetArtiekel(int id)
        {
            var artiekel = await _context.Artiekel.FindAsync(id);

            if (artiekel == null)
            {
                return NotFound();
            }

            return artiekel;
        }

        // PUT: api/Artiekel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtiekel(int id, Artiekel artiekel)
        {
            if (id != artiekel.Id)
            {
                return BadRequest();
            }

            _context.Entry(artiekel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtiekelExists(id))
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

        // POST: api/Artiekel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artiekel>> PostArtiekel(Artiekel artiekel)
        {
            _context.Artiekel.Add(artiekel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtiekel", new { id = artiekel.Id }, artiekel);
        }

        // DELETE: api/Artiekel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtiekel(int id)
        {
            var artiekel = await _context.Artiekel.FindAsync(id);
            if (artiekel == null)
            {
                return NotFound();
            }

            _context.Artiekel.Remove(artiekel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtiekelExists(int id)
        {
            return _context.Artiekel.Any(e => e.Id == id);
        }
    }
}
