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
    public class GIANGVIENController : ControllerBase
    {
        private readonly DbQLPMContext _context;

        public GIANGVIENController(DbQLPMContext context)
        {
            _context = context;
        }

        // GET: api/GIANGVIEN
        [HttpGet]
        public IEnumerable<GIANGVIEN> GetGIANGVIEN()
        {
            return _context.GIANGVIEN;
        }

        // GET: api/GIANGVIEN/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGIANGVIEN([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gIANGVIEN = await _context.GIANGVIEN.FindAsync(id);

            if (gIANGVIEN == null)
            {
                return NotFound();
            }

            return Ok(gIANGVIEN);
        }

        // PUT: api/GIANGVIEN/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGIANGVIEN([FromRoute] string id, [FromBody] GIANGVIEN gIANGVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gIANGVIEN.MAGV)
            {
                return BadRequest();
            }

            _context.Entry(gIANGVIEN).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GIANGVIENExists(id))
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

        // POST: api/GIANGVIEN
        [HttpPost]
        public async Task<IActionResult> PostGIANGVIEN([FromBody] GIANGVIEN gIANGVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GIANGVIEN.Add(gIANGVIEN);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGIANGVIEN", new { id = gIANGVIEN.MAGV }, gIANGVIEN);
        }

        // DELETE: api/GIANGVIEN/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGIANGVIEN([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gIANGVIEN = await _context.GIANGVIEN.FindAsync(id);
            if (gIANGVIEN == null)
            {
                return NotFound();
            }

            _context.GIANGVIEN.Remove(gIANGVIEN);
            await _context.SaveChangesAsync();

            return Ok(gIANGVIEN);
        }

        private bool GIANGVIENExists(string id)
        {
            return _context.GIANGVIEN.Any(e => e.MAGV == id);
        }
    }
}