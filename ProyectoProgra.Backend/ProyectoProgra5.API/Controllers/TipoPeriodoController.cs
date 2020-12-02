using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.DAL.EF;
using data = Solution.DO.Objects;

namespace ProyectoProgra5.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPeriodoController : Controller
    {
        private readonly SolutionDBContext _context;

        public TipoPeriodoController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/TipoPeriodo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.TipoPeriodo>>> GetTipoPeriodos()
        {
            return new Solution.BS.TipoPeriodo(_context).GetAll().ToList();
        }

        // GET: api/TipoPeriodo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.TipoPeriodo>> GetTipoPeriodo(int id)
        {
            var tipoPeriodo = new Solution.BS.TipoPeriodo(_context).GetOneById(id);

            if (tipoPeriodo == null)
            {
                return NotFound();
            }

            return tipoPeriodo;
        }

        // PUT: api/TipoPeriodo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPeriodo(int id, data.TipoPeriodo tipoPeriodo)
        {
            if (id != tipoPeriodo.IdPeriodo)
            {
                return BadRequest();
            }

            try
            {
                new Solution.BS.TipoPeriodo(_context).Update(tipoPeriodo);
            }
            catch (Exception)
            {
                if (!TipoPeriodoExists(id))
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

        // POST: api/TipoPeriodo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.TipoPeriodo>> PostTipoPeriodo(data.TipoPeriodo tipoPeriodo)
        {
            new Solution.BS.TipoPeriodo(_context).Insert(tipoPeriodo);

            return CreatedAtAction("GetTipoPeriodo", new { id = tipoPeriodo.IdPeriodo }, tipoPeriodo);
        }

        // DELETE: api/TipoPeriodo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.TipoPeriodo>> DeleteTipoPeriodo(int id)
        {
            var tipoPeriodo = new Solution.BS.TipoPeriodo(_context).GetOneById(id);
            if (tipoPeriodo == null)
            {
                return NotFound();
            }

            new Solution.BS.TipoPeriodo(_context).Delete(tipoPeriodo);

            return tipoPeriodo;
        }

        private bool TipoPeriodoExists(int id)
        {
            return (new Solution.BS.TipoPeriodo(_context).GetOneById(id) != null);
        }
    }
}
