using burguermania_backend.Models;
using Microsoft.AspNetCore.Mvc;
using burguermania_backend.Context;
using Microsoft.EntityFrameworkCore;

namespace burguermania_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class StatusController : ControllerBase {
        private readonly BurguerManiaDbContext _context;

        public StatusController(BurguerManiaDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatus() {
            var status = await _context.Status.ToListAsync();

            if (!status.Any()) {
                return NotFound("Status não encontrados");
            }

            return Ok(new {message="Status encontrados com sucesso!", status});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult <Status>> GetStatus(int id){
            var status = await _context.Status.FirstOrDefaultAsync(s => s.Id == id);

            if (status == null) {
                return NotFound("Status não encontrado");
            }

            return Ok(new {message = "Status encontrado com sucesso!", status});
        }

        [HttpPost]
        public async Task<ActionResult<Status>> PostStatus(Status status) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _context.Status.Add(status);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStatus), new { id = status.Id }, new {message = "Status criado com sucesso!", status});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(int id, Status status) { 
            if(id != status.Id) {
                return BadRequest("ID do status não corresponde ao status enviado.");
            }   

            var existingStatus = await _context.Status.FirstOrDefaultAsync(s => s.Id == id);
            if (existingStatus == null) {
                return NotFound("Status não encontrado para atualização.");
            }

            _context.Entry(status).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new {message = "Status atualizado com sucesso!", status});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id){
            var status = await _context.Status.FirstOrDefaultAsync(p => p.Id == id);
            if (status == null){
                return NotFound("Status não encontrado.");
            }

            _context.Status.Remove(status);
            await _context.SaveChangesAsync();

            return Ok(new {message = "Status removido com sucesso!", status});
        }
    }
}