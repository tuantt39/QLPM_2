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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TAIKHOANController : ControllerBase
    {
        private readonly DbQLPMContext _context;

        public TAIKHOANController(DbQLPMContext context)
        {
            _context = context;
        }

        // GET: api/TAIKHOAN
        [HttpGet]
        public IEnumerable<TAIKHOAN> GetTAIKHOAN()
        {
            return _context.TAIKHOAN;
        }

        // GET: api/TAIKHOAN/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTAIKHOAN([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tAIKHOAN = await _context.TAIKHOAN.FindAsync(id);

            if (tAIKHOAN == null)
            {
                return NotFound();
            }

            return Ok(tAIKHOAN);
        }

        // PUT: api/TAIKHOAN/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTAIKHOAN([FromRoute] int id, [FromBody] TAIKHOAN tAIKHOAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tAIKHOAN.ID)
            {
                return BadRequest();
            }

            _context.Entry(tAIKHOAN).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TAIKHOANExists(id))
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

        // POST: api/TAIKHOAN
        [HttpPost]
        public async Task<IActionResult> PostTAIKHOAN([FromBody] TAIKHOAN tAIKHOAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TAIKHOAN.Add(tAIKHOAN);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTAIKHOAN", new { id = tAIKHOAN.ID }, tAIKHOAN);
        }

        // DELETE: api/TAIKHOAN/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTAIKHOAN([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tAIKHOAN = await _context.TAIKHOAN.FindAsync(id);
            if (tAIKHOAN == null)
            {
                return NotFound();
            }

            _context.TAIKHOAN.Remove(tAIKHOAN);
            await _context.SaveChangesAsync();

            return Ok(tAIKHOAN);
        }

        private bool TAIKHOANExists(int id)
        {
            return _context.TAIKHOAN.Any(e => e.ID == id);
        }
    }
}