using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConsultorioApi.Data;
using ConsultorioApi.Models;
using ConsultorioApi.DTOs;

namespace ConsultorioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TurnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Turnos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TurnoDTO>>> GetTurnos()
        {
            var turnos = await _context.Turnos
                .Include(t => t.Medico)
                .Include(t => t.Paciente)
                .ToListAsync();

            var turnosDto = turnos.Select(t => new TurnoDTO
            {
                Id = t.Id,
                FechaHora = t.FechaHora.ToString("dd-MM-yyyy HH:mm"),
                Medico = t.Medico,
                Paciente = t.Paciente
            });

            return Ok(turnosDto);
        }

        // GET: api/Turnos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TurnoDTO>> GetTurno(int id)
        {
            var turno = await _context.Turnos
                .Include(t => t.Medico)
                .Include(t => t.Paciente)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (turno == null)
            {
                return NotFound();
            }

            var turnoDto = new TurnoDTO
            {
                Id = turno.Id,
                FechaHora = turno.FechaHora.ToString("dd-MM-yyyy HH:mm"),
                Medico = turno.Medico,
                Paciente = turno.Paciente
            };

            return Ok(turnoDto);
        }

        // PUT: api/Turnos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurno(int id, Turno turno)
        {
            if (id != turno.Id)
            {
                return BadRequest();
            }

            _context.Entry(turno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurnoExists(id))
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

        // POST: api/Turnos
        [HttpPost]
        public async Task<ActionResult<TurnoDTO>> PostTurno(Turno turno)
        {
            if (_context.Turnos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Turnos' is null.");
            }

            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();

            // Cargar relaciones para incluir Medico y Paciente
            await _context.Entry(turno).Reference(t => t.Medico).LoadAsync();
            await _context.Entry(turno).Reference(t => t.Paciente).LoadAsync();

            var turnoDto = new TurnoDTO
            {
                Id = turno.Id,
                FechaHora = turno.FechaHora.ToString("dd-MM-yyyy HH:mm"),
                Medico = turno.Medico,
                Paciente = turno.Paciente
            };

            return CreatedAtAction(nameof(GetTurno), new { id = turno.Id }, turnoDto);
        }

        // DELETE: api/Turnos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurno(int id)
        {
            if (_context.Turnos == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }

            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TurnoExists(int id)
        {
            return (_context.Turnos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}