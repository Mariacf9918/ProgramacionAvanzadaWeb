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
    public class RolesController : Controller
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public RolesController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Roles>>> GetRoles()
        {
            var result = new Solution.BS.Roles(_context).GetAll().ToList();
            var aux = _mapper.Map<IEnumerable<data.Roles>, IEnumerable<Models.Roles>>(result);
            return aux.ToList();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Roles>> GetRole(int id)
        {
            var role = new Solution.BS.Roles(_context).GetOneById(id);
            var aux = _mapper.Map<data.Roles, Models.Roles>(role);
            if (aux == null)
            {
                return NotFound();
            }

            return aux;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Models.Roles role)
        {
            if (id != role.IdRol)
            {
                return BadRequest();
            }

            try
            {
                var aux = _mapper.Map<Models.Roles, data.Roles>(role);
                new Solution.BS.Roles(_context).Update(aux);
            }
            catch (Exception)
            {
                if (!RoleExists(id))
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

        // POST: api/Roles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Models.Roles>> PostRole(Models.Roles role)
        {
            var aux = _mapper.Map<Models.Roles, data.Roles>(role);
            new Solution.BS.Roles(_context).Insert(aux);

            return CreatedAtAction("GetRole", new { id = role.IdRol }, role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Roles>> DeleteRole(int id)
        {
            var role = new Solution.BS.Roles(_context).GetOneById(id);
            var aux = _mapper.Map<data.Roles, Models.Roles>(role);
            if (aux == null)
            {
                return NotFound();
            }

            new Solution.BS.Roles(_context).Delete(role);

            return aux;
        }

        private bool RoleExists(int id)
        {
            return (new Solution.BS.Roles(_context).GetOneById(id) != null);
        }
    }
}
