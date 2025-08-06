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
    public class ApartamentosController : ControllerBase
    {
        private readonly ContextoBaseDatos _context;

        public ApartamentosController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: api/Apartamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartamento>>> GetApartamentos()
        {
            var lista = await _context.Apartamentos
                                //.Where(apartamento => apartamento.Ciudad.Contains("a") && apartamento.Puerta.Contains("1"))
                                //.Where(apartamento => apartamento.Ciudad == "Zanebury")
                                .OrderBy(apartamento => apartamento.Nombre)
                                .ToListAsync()   ;



            return Ok(lista);

            // return await _context.Apartamentos .ToListAsync();
        }

        // GET: api/Apartamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Apartamento>> GetApartamento(int id)
        {
            var apartamento = await _context.Apartamentos.FindAsync(id);

            if (apartamento == null)
            {
                return NotFound();
            }

            return apartamento;
        }

        // PUT: api/Apartamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApartamento(int id, Apartamento apartamento)
        {
            if (id != apartamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(apartamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartamentoExists(id))
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

        // POST: api/Apartamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Apartamento>> PostApartamento(Apartamento apartamento)
        {
            _context.Apartamentos.Add(apartamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApartamento", new { id = apartamento.Id }, apartamento);
        }

        // DELETE: api/Apartamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartamento(int id)
        {
            var apartamento = await _context.Apartamentos.FindAsync(id);
            if (apartamento == null)
            {
                return NotFound();
            }

            _context.Apartamentos.Remove(apartamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApartamentoExists(int id)
        {
            return _context.Apartamentos.Any(e => e.Id == id);
        }
    }
}
