using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public TipoPeriodoController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TipoPeriodo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.TipoPeriodo>>> GetTipoPeriodos()
        {
            var aux = await new Solution.BS.TipoPeriodo(_context).GetAllInclude();
            return _mapper.Map<IEnumerable<data.TipoPeriodo>, IEnumerable<Models.TipoPeriodo>>(aux).ToList();
        }

        // GET: api/TipoPeriodo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.TipoPeriodo>> GetTipoPeriodo(int id)
        {
            var tipoPeriodo = await new Solution.BS.TipoPeriodo(_context).GetOneByIdInclude(id);
            var result = _mapper.Map<data.TipoPeriodo, Models.TipoPeriodo>(tipoPeriodo);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/TipoPeriodo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPeriodo(int id, Models.TipoPeriodo tipoPeriodo)
        {
            if (id != tipoPeriodo.IdPeriodo)
            {
                return BadRequest();
            }

            try
            {
                var result = _mapper.Map<Models.TipoPeriodo, data.TipoPeriodo>(tipoPeriodo);
                new Solution.BS.TipoPeriodo(_context).Update(result);
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
        public async Task<ActionResult<Models.TipoPeriodo>> PostTipoPeriodo(Models.TipoPeriodo tipoPeriodo)
        {
            var result = _mapper.Map<Models.TipoPeriodo, data.TipoPeriodo>(tipoPeriodo);
            new Solution.BS.TipoPeriodo(_context).Insert(result);

            return CreatedAtAction("GetTipoPeriodo", new { id = tipoPeriodo.IdPeriodo }, tipoPeriodo);
        }

        // DELETE: api/TipoPeriodo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.TipoPeriodo>> DeleteTipoPeriodo(int id)
        {
            var tipoPeriodo = new Solution.BS.TipoPeriodo(_context).GetOneById(id);
            var result = _mapper.Map<data.TipoPeriodo, Models.TipoPeriodo>(tipoPeriodo);
            if (tipoPeriodo == null)
            {
                return NotFound();
            }

            new Solution.BS.TipoPeriodo(_context).Delete(tipoPeriodo);

            return result;
        }

        private bool TipoPeriodoExists(int id)
        {
            return (new Solution.BS.TipoPeriodo(_context).GetOneById(id) != null);
        }
    }
}
