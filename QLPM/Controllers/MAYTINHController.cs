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
    public class MAYTINHController : ControllerBase
    {
        private readonly DbQLPMContext _context;

        public MAYTINHController(DbQLPMContext context)
        {
            _context = context;
        }

        // GET: api/MAYTINH
        [HttpGet]
        public IEnumerable<MAYTINH> GetMAYTINH()
        {
            return _context.MAYTINH;
        }

        // GET: api/MAYTINH/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMAYTINH([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mAYTINH = await _context.MAYTINH.FindAsync(id);

            if (mAYTINH == null)
            {
                return NotFound();
            }

            return Ok(mAYTINH);
        }

        // PUT: api/MAYTINH/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMAYTINH([FromRoute] int id, [FromBody] MAYTINH mAYTINH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mAYTINH.MAMT)
            {
                return BadRequest();
            }

            _context.Entry(mAYTINH).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MAYTINHExists(id))
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

        // POST: api/MAYTINH
        [HttpPost]
        public async Task<IActionResult> PostMAYTINH([FromBody] MAYTINH mAYTINH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MAYTINH.Add(mAYTINH);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMAYTINH", new { id = mAYTINH.MAMT }, mAYTINH);
        }

        // DELETE: api/MAYTINH/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMAYTINH([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mAYTINH = await _context.MAYTINH.FindAsync(id);
            if (mAYTINH == null)
            {
                return NotFound();
            }

            _context.MAYTINH.Remove(mAYTINH);
            await _context.SaveChangesAsync();

            return Ok(mAYTINH);
        }

        private bool MAYTINHExists(int id)
        {
            return _context.MAYTINH.Any(e => e.MAMT == id);
        }
    }
}