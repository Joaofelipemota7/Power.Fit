using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using powerfit_api.Data;
using powerfit_api.Models;

namespace powerfit_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalidadesController : ControllerBase
    {
        private readonly PowerFitContext _context;

        public ModalidadesController(PowerFitContext context)
        {
            _context = context;
        }

        // GET: api/Modalidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modalidade>>> GetModalidades()
        {
            return await _context.Modalidades.ToListAsync();
        }

        // GET: api/Modalidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modalidade>> GetModalidade(int id)
        {
            var modalidade = await _context.Modalidades.FindAsync(id);

            if (modalidade == null)
            {
                return NotFound();
            }

            return modalidade;
        }

        // PUT: api/Modalidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModalidade(int id, Modalidade modalidade)
        {
            if (id != modalidade.ModalidadeId)
            {
                return BadRequest();
            }

            _context.Entry(modalidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModalidadeExists(id))
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

        // POST: api/Modalidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Modalidade>> PostModalidade(Modalidade modalidade)
        {
            _context.Modalidades.Add(modalidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModalidade", new { id = modalidade.ModalidadeId }, modalidade);
        }

        // DELETE: api/Modalidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModalidade(int id)
        {
            var modalidade = await _context.Modalidades.FindAsync(id);
            if (modalidade == null)
            {
                return NotFound();
            }

            _context.Modalidades.Remove(modalidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModalidadeExists(int id)
        {
            return _context.Modalidades.Any(e => e.ModalidadeId == id);
        }
    }
}
