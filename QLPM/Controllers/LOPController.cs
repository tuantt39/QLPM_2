using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLPM.DAO;
using QLPM.Models;

namespace QLPM.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LOPController : ControllerBase
    {
        private readonly DbQLPMContext _context;

        public LOPController(DbQLPMContext context)
        {
            _context = context;
        }

        // GET: api/LOP
        [HttpGet]
        public IEnumerable<LOP> GetLOP()
        {
            return _context.LOP;
        }

        // GET: api/LOP/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLOP([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lOP = await _context.LOP.FindAsync(id);

            if (lOP == null)
            {
                return NotFound();
            }

            return Ok(lOP);
        }

        // PUT: api/LOP/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLOP([FromRoute] string id, [FromBody] LOP lOP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lOP.MALOP)
            {
                return BadRequest();
            }

            _context.Entry(lOP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LOPExists(id))
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

        // POST: api/LOP
        [HttpPost]
        public async Task<IActionResult> PostLOP([FromBody] LOP lOP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LOP.Add(lOP);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLOP", new { id = lOP.MALOP }, lOP);
        }

        // DELETE: api/LOP/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLOP([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lOP = await _context.LOP.FindAsync(id);
            if (lOP == null)
            {
                return NotFound();
            }

            _context.LOP.Remove(lOP);
            await _context.SaveChangesAsync();

            return Ok(lOP);
        }

        private bool LOPExists(string id)
        {
            return _context.LOP.Any(e => e.MALOP == id);
        }
    }
}