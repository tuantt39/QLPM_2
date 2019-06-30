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
    public class PHONGController : ControllerBase
    {
        private readonly DbQLPMContext _context;

        public PHONGController(DbQLPMContext context)
        {
            _context = context;
        }

        // GET: api/PHONG
        [HttpGet]
        public IEnumerable<PHONG> GetPHONG()
        {
            return _context.PHONG;
        }

        // GET: api/PHONG/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPHONG([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pHONG = await _context.PHONG.FindAsync(id);

            if (pHONG == null)
            {
                return NotFound();
            }

            return Ok(pHONG);
        }

        // PUT: api/PHONG/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPHONG([FromRoute] string id, [FromBody] PHONG pHONG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pHONG.MAPHONG)
            {
                return BadRequest();
            }

            _context.Entry(pHONG).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PHONGExists(id))
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

        // POST: api/PHONG
        [HttpPost]
        public async Task<IActionResult> PostPHONG([FromBody] PHONG pHONG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PHONG.Add(pHONG);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPHONG", new { id = pHONG.MAPHONG }, pHONG);
        }

        // DELETE: api/PHONG/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePHONG([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pHONG = await _context.PHONG.FindAsync(id);
            if (pHONG == null)
            {
                return NotFound();
            }

            _context.PHONG.Remove(pHONG);
            await _context.SaveChangesAsync();

            return Ok(pHONG);
        }

        private bool PHONGExists(string id)
        {
            return _context.PHONG.Any(e => e.MAPHONG == id);
        }
    }
}