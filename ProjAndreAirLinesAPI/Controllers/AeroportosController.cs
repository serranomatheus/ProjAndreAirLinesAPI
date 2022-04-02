using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjAndreAirLinesAPI.Data;
using ProjAndreAirLinesAPI.Model;

namespace ProjAndreAirLinesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AeroportosController : ControllerBase
    {
        private readonly ProjAndreAirLinesAPIContext _context;

        public AeroportosController(ProjAndreAirLinesAPIContext context)
        {
            _context = context;
        }

        // GET: api/Aeroportos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aeroporto>>> GetAeroporto()
        {
            return await _context.Aeroporto.Include(e => e.Endereco).ToListAsync();
        }

        // GET: api/Aeroportos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aeroporto>> GetAeroporto(string id)
        {
            var aeroporto = await _context.Aeroporto
                            .Include(e => e.Endereco)
                            .Where(d => d.Sigla == id).FirstOrDefaultAsync();

            if (aeroporto == null)
            {
                return NotFound();
            }

            return aeroporto;
        }

        // PUT: api/Aeroportos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAeroporto(string id, Aeroporto aeroporto)
        {
            if (id != aeroporto.Sigla)
            {
                return BadRequest();
            }

            _context.Entry(aeroporto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeroportoExists(id))
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

        // POST: api/Aeroportos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aeroporto>> PostAeroporto(Aeroporto aeroporto)
        {
            var endereco = await _context.Endereco
                            .Where(x => x.Id == aeroporto.Endereco.Id)
                            .FirstOrDefaultAsync();

            aeroporto.Endereco = endereco;
            _context.Aeroporto.Add(aeroporto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AeroportoExists(aeroporto.Sigla))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAeroporto", new { id = aeroporto.Sigla }, aeroporto);
        }

        // DELETE: api/Aeroportos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeroporto(string id)
        {
            var aeroporto = await _context.Aeroporto.FindAsync(id);
            if (aeroporto == null)
            {
                return NotFound();
            }

            _context.Aeroporto.Remove(aeroporto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeroportoExists(string id)
        {
            return _context.Aeroporto.Any(e => e.Sigla == id);
        }
    }
}
