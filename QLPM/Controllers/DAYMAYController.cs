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
    public class DAYMAYController : ControllerBase
    {
        private readonly DbQLPMContext _context;

        public DAYMAYController(DbQLPMContext context)
        {
            _context = context;
        }

        // GET: api/DAYMAY
        [HttpGet]
        public IEnumerable<DAYMAY> GetDAYMAY()
        {
            return _context.DAYMAY;
        }

        // GET: api/DAYMAY/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDAYMAY([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dAYMAY = await _context.DAYMAY.FindAsync(id);

            if (dAYMAY == null)
            {
                return NotFound();
            }

            return Ok(dAYMAY);
        }

        // PUT: api/DAYMAY/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDAYMAY([FromRoute] string id, [FromBody] DAYMAY dAYMAY)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dAYMAY.MADM)
            {
                return BadRequest();
            }

            _context.Entry(dAYMAY).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DAYMAYExists(id))
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

        // POST: api/DAYMAY
        [HttpPost]
        public async Task<IActionResult> PostDAYMAY([FromBody] DAYMAY dAYMAY)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DAYMAY.Add(dAYMAY);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDAYMAY", new { id = dAYMAY.MADM }, dAYMAY);
        }

        // DELETE: api/DAYMAY/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDAYMAY([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dAYMAY = await _context.DAYMAY.FindAsync(id);
            if (dAYMAY == null)
            {
                return NotFound();
            }

            _context.DAYMAY.Remove(dAYMAY);
            await _context.SaveChangesAsync();

            return Ok(dAYMAY);
        }

        private bool DAYMAYExists(string id)
        {
            return _context.DAYMAY.Any(e => e.MADM == id);
        }
    }
}