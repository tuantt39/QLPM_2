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
    public class DANGKYTIETHOCController : ControllerBase
    {
        private readonly DbQLPMContext _context;

        public DANGKYTIETHOCController(DbQLPMContext context)
        {
            _context = context;
        }

        // GET: api/DANGKYTIETHOC
        [HttpGet]
        public IEnumerable<DANGKYTIETHOC> GetDANGKYTIETHOC()
        {
            return _context.DANGKYTIETHOC;
        }

        // GET: api/DANGKYTIETHOC/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDANGKYTIETHOC([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dANGKYTIETHOC = await _context.DANGKYTIETHOC.FindAsync(id);

            if (dANGKYTIETHOC == null)
            {
                return NotFound();
            }

            return Ok(dANGKYTIETHOC);
        }

        // PUT: api/DANGKYTIETHOC/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDANGKYTIETHOC([FromRoute] int id, [FromBody] DANGKYTIETHOC dANGKYTIETHOC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dANGKYTIETHOC.ID)
            {
                return BadRequest();
            }

            _context.Entry(dANGKYTIETHOC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DANGKYTIETHOCExists(id))
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

        // POST: api/DANGKYTIETHOC
        [HttpPost]
        public async Task<IActionResult> PostDANGKYTIETHOC([FromBody] DANGKYTIETHOC dANGKYTIETHOC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DANGKYTIETHOC.Add(dANGKYTIETHOC);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDANGKYTIETHOC", new { id = dANGKYTIETHOC.ID }, dANGKYTIETHOC);
        }

        // DELETE: api/DANGKYTIETHOC/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDANGKYTIETHOC([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dANGKYTIETHOC = await _context.DANGKYTIETHOC.FindAsync(id);
            if (dANGKYTIETHOC == null)
            {
                return NotFound();
            }

            _context.DANGKYTIETHOC.Remove(dANGKYTIETHOC);
            await _context.SaveChangesAsync();

            return Ok(dANGKYTIETHOC);
        }

        private bool DANGKYTIETHOCExists(int id)
        {
            return _context.DANGKYTIETHOC.Any(e => e.ID == id);
        }
    }
}