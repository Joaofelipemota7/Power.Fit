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
    public class AlunosModalidadesController : ControllerBase
    {
        private readonly PowerFitContext _context;

        public AlunosModalidadesController(PowerFitContext context)
        {
            _context = context;
        }

        // GET: api/AlunosModalidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoModalidade>>> GetAlunosModalidades()
        {
            return await _context.AlunosModalidades.ToListAsync();
        }

        // GET: api/AlunosModalidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoModalidade>> GetAlunoModalidade(int id)
        {
            var alunoModalidade = await _context.AlunosModalidades.FindAsync(id);

            if (alunoModalidade == null)
            {
                return NotFound();
            }

            return alunoModalidade;
        }

        // PUT: api/AlunosModalidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlunoModalidade(int id, AlunoModalidade alunoModalidade)
        {
            if (id != alunoModalidade.AlunoModalidadeId)
            {
                return BadRequest();
            }

            _context.Entry(alunoModalidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoModalidadeExists(id))
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

        // POST: api/AlunosModalidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlunoModalidade>> PostAlunoModalidade(AlunoModalidade alunoModalidade)
        {
            _context.AlunosModalidades.Add(alunoModalidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlunoModalidade", new { id = alunoModalidade.AlunoModalidadeId }, alunoModalidade);
        }

        // DELETE: api/AlunosModalidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlunoModalidade(int id)
        {
            var alunoModalidade = await _context.AlunosModalidades.FindAsync(id);
            if (alunoModalidade == null)
            {
                return NotFound();
            }

            _context.AlunosModalidades.Remove(alunoModalidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoModalidadeExists(int id)
        {
            return _context.AlunosModalidades.Any(e => e.AlunoModalidadeId == id);
        }
    }
}
