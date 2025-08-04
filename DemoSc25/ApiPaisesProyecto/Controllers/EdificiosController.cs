using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPaisesProyecto.BaseDatos;
using ApiPaisesProyecto.Entidades;

namespace ApiPaisesProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdificiosController : ControllerBase
    {
        private readonly ContextoBaseDatos _context;

        public EdificiosController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: api/Edificios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Edificio>>> GetEdificios()
        {
            return await _context.Edificios.ToListAsync();
        }

        // GET: api/Edificios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Edificio>> GetEdificio(int id)
        {
            var edificio = await _context.Edificios.FindAsync(id);

            if (edificio == null)
            {
                return NotFound();
            }

            return edificio;
        }

        // PUT: api/Edificios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEdificio(int id, Edificio edificio)
        {
            if (id != edificio.Id)
            {
                return BadRequest();
            }

            _context.Entry(edificio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EdificioExists(id))
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

        // POST: api/Edificios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Edificio>> PostEdificio(Edificio edificio)
        {
            _context.Edificios.Add(edificio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEdificio", new { id = edificio.Id }, edificio);
        }

        // DELETE: api/Edificios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEdificio(int id)
        {
            var edificio = await _context.Edificios.FindAsync(id);
            if (edificio == null)
            {
                return NotFound();
            }

            _context.Edificios.Remove(edificio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EdificioExists(int id)
        {
            return _context.Edificios.Any(e => e.Id == id);
        }
    }
}
