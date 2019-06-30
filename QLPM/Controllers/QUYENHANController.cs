using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLPM.DAO;
using QLPM.Model;

namespace QLPM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QUYENHANController : ControllerBase
    {
        private readonly DbQLPMContext _context;

        public QUYENHANController(DbQLPMContext context)
        {
            _context = context;
        }

        // GET: api/QUYENHAN
        [HttpGet]
        public IEnumerable<QUYENHAN> GetQUYENHAN()
        {
            return _context.QUYENHAN;
        }

        // GET: api/QUYENHAN/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQUYENHAN([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var qUYENHAN = await _context.QUYENHAN.FindAsync(id);

            if (qUYENHAN == null)
            {
                return NotFound();
            }

            return Ok(qUYENHAN);
        }

        // PUT: api/QUYENHAN/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQUYENHAN([FromRoute] string id, [FromBody] QUYENHAN qUYENHAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != qUYENHAN.MAQH)
            {
                return BadRequest();
            }

            _context.Entry(qUYENHAN).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QUYENHANExists(id))
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

        // POST: api/QUYENHAN
        [HttpPost]
        public async Task<IActionResult> PostQUYENHAN([FromBody] QUYENHAN qUYENHAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.QUYENHAN.Add(qUYENHAN);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQUYENHAN", new { id = qUYENHAN.MAQH }, qUYENHAN);
        }

        // DELETE: api/QUYENHAN/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQUYENHAN([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var qUYENHAN = await _context.QUYENHAN.FindAsync(id);
            if (qUYENHAN == null)
            {
                return NotFound();
            }

            _context.QUYENHAN.Remove(qUYENHAN);
            await _context.SaveChangesAsync();

            return Ok(qUYENHAN);
        }

        private bool QUYENHANExists(string id)
        {
            return _context.QUYENHAN.Any(e => e.MAQH == id);
        }
    }
}