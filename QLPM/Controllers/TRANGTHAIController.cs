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
    public class TRANGTHAIController : ControllerBase
    {
        private readonly DbQLPMContext _context;

        public TRANGTHAIController(DbQLPMContext context)
        {
            _context = context;
        }

        // GET: api/TRANGTHAI
        [HttpGet]
        public IEnumerable<TRANGTHAI> GetTRANGTHAI()
        {
            return _context.TRANGTHAI;
        }

        // GET: api/TRANGTHAI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTRANGTHAI([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tRANGTHAI = await _context.TRANGTHAI.FindAsync(id);

            if (tRANGTHAI == null)
            {
                return NotFound();
            }

            return Ok(tRANGTHAI);
        }

        // PUT: api/TRANGTHAI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTRANGTHAI([FromRoute] int id, [FromBody] TRANGTHAI tRANGTHAI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tRANGTHAI.MATT)
            {
                return BadRequest();
            }

            _context.Entry(tRANGTHAI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TRANGTHAIExists(id))
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

        // POST: api/TRANGTHAI
        [HttpPost]
        public async Task<IActionResult> PostTRANGTHAI([FromBody] TRANGTHAI tRANGTHAI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TRANGTHAI.Add(tRANGTHAI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTRANGTHAI", new { id = tRANGTHAI.MATT }, tRANGTHAI);
        }

        // DELETE: api/TRANGTHAI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTRANGTHAI([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tRANGTHAI = await _context.TRANGTHAI.FindAsync(id);
            if (tRANGTHAI == null)
            {
                return NotFound();
            }

            _context.TRANGTHAI.Remove(tRANGTHAI);
            await _context.SaveChangesAsync();

            return Ok(tRANGTHAI);
        }

        private bool TRANGTHAIExists(int id)
        {
            return _context.TRANGTHAI.Any(e => e.MATT == id);
        }
    }
}