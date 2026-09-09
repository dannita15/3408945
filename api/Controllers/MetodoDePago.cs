using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Tienda.API.Data;
using Tienda.API.Models;
namespace Tienda.API.Controllers
{
    [ApiController]
    [Route("GestionClientesDannaMorales/[controller]")]
    public class MetodoDePagoController : ControllerBase
    {
        private readonly TiendaDbContext _context;
        public MetodoDePagoController (TiendaDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetodoDePago>>> GetMetodosDePago()
        {
            return await _context.MetodoDePago.ToListAsync();
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<MetodoDePago>> GetMetodoDePago(int id)
        {
            var metodoDePago = await _context.MetodoDePago.FindAsync(id);
            if (metodoDePago == null)
            {
                return NotFound();
            }
            return metodoDePago;
        }
        [HttpPost]
        public async Task<ActionResult<MetodoDePago>> PostMetodoDePago(MetodoDePago metodoDePago)
        {
            _context.MetodoDePago.Add(metodoDePago);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMetodoDePago),
             new { id = metodoDePago.IdMetodoDePago }, metodoDePago);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetodoDePago(int id, MetodoDePago metodoDePago)
        {
            if (id != metodoDePago.IdMetodoDePago) return BadRequest();
            _context.Entry(metodoDePago).State = EntityState.Modified;
            try

            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.MetodoDePago.Any(m => m.IdMetodoDePago == id))
                    return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetodoDePago(int id)
        {
            var metodoDePago = await _context.MetodoDePago.FindAsync(id);
            if (metodoDePago == null) return NotFound();
            _context.MetodoDePago.Remove(metodoDePago);
            await _context.SaveChangesAsync();
            return NoContent();
        }



    }
}
