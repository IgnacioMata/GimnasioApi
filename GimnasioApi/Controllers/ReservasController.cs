using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GimnasioApi.Data;
using GimnasioApi.Models;
using GimnasioApi.DTOs;

namespace GimnasioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaDTO>>> GetReservas()
        {
            var reservas = await _context.Reservas
                .Include(r => r.Entrenador)
                .Include(r => r.Socio)
                .ToListAsync();

            var reservasDto = reservas.Select(r => new ReservaDTO
            {
                Id = r.Id,
                FechaHora = r.FechaHora.ToString("dd-MM-yyyy HH:mm"),
                Entrenador = r.Entrenador,
                Socio = r.Socio
            });

            return Ok(reservasDto);
        }

        // GET: api/Reservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaDTO>> GetReserva(int id)
        {
            var reserva = await _context.Reservas
                .Include(r => r.Entrenador)
                .Include(r => r.Socio)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reserva == null)
            {
                return NotFound();
            }

            var reservaDto = new ReservaDTO
            {
                Id = reserva.Id,
                FechaHora = reserva.FechaHora.ToString("dd-MM-yyyy HH:mm"),
                Entrenador = reserva.Entrenador,
                Socio = reserva.Socio
            };

            return Ok(reservaDto);
        }

        // PUT: api/Reservas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return BadRequest();
            }

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
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

        // POST: api/Reservas
        [HttpPost]
        public async Task<ActionResult<ReservaDTO>> PostReserva(Reserva reserva)
        {
            if (_context.Reservas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reservas' is null.");
            }

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            await _context.Entry(reserva).Reference(r => r.Entrenador).LoadAsync();
            await _context.Entry(reserva).Reference(r => r.Socio).LoadAsync();

            var reservaDto = new ReservaDTO
            {
                Id = reserva.Id,
                FechaHora = reserva.FechaHora.ToString("dd-MM-yyyy HH:mm"),
                Entrenador = reserva.Entrenador,
                Socio = reserva.Socio
            };

            return CreatedAtAction(nameof(GetReserva), new { id = reserva.Id }, reservaDto);
        }

        // DELETE: api/Reservas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            if (_context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservaExists(int id)
        {
            return (_context.Reservas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
