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
    public class RolesController : Controller
    {
        private readonly SolutionDBContext _context;

        public RolesController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Roles>>> GetRoles()
        {
            return new Solution.BS.Roles(_context).GetAll().ToList();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Roles>> GetRole(int id)
        {
            var role = new Solution.BS.Roles(_context).GetOneById(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, data.Roles role)
        {
            if (id != role.IdRol)
            {
                return BadRequest();
            }

            try
            {
                new Solution.BS.Roles(_context).Update(role);
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
        public async Task<ActionResult<data.Roles>> PostRole(data.Roles role)
        {
            new Solution.BS.Roles(_context).Insert(role);

            return CreatedAtAction("GetRole", new { id = role.IdRol }, role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Roles>> DeleteRole(int id)
        {
            var role = new Solution.BS.Roles(_context).GetOneById(id);
            if (role == null)
            {
                return NotFound();
            }

            new Solution.BS.Roles(_context).Delete(role);

            return role;
        }

        private bool RoleExists(int id)
        {
            return (new Solution.BS.Roles(_context).GetOneById(id) != null);
        }
    }
}
