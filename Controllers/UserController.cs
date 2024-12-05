using burguermania_backend.Models;
using Microsoft.AspNetCore.Mvc;
using burguermania_backend.Context;
using Microsoft.EntityFrameworkCore;
using burguermania_backend.Interfaces;

namespace burguermania_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly BurguerManiaDbContext _context;

        public UserController(BurguerManiaDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers() {
            var users = await _context.Users.Include(u => u.UserOrders).ToListAsync();

            if (!users.Any()) {
                return NotFound("Usuários não encontrados");
            }

            var usersInterface = users.Select(u => new IUser
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
            }).ToList();

            return Ok(new { message = "Usuários encontrados com sucesso!", users = usersInterface});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id) {
            var user = await _context.Users.Include(u => u.UserOrders).FirstOrDefaultAsync(u => u.Id == id);

            if (user == null) {
                return NotFound("Usuário não encontrado");
            }

            var userInterface = UserPipe(user);

            return Ok(new { message = "Usuário encontrado com sucesso!", user = userInterface});
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var userInterface = UserPipe(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, new { message = "Usuário criado com sucesso", user = userInterface});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user) {
            if (id != user.Id) {
                return BadRequest("ID do usuário não corresponde ao usuário enviado.");
            }

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser == null) {
                return NotFound("Usuário não encontrado para atualização.");
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var userInterface = UserPipe(user);

            return Ok(new { message = "Usuário atualizado com sucesso!", user = userInterface});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id) {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) {
                return NotFound("Usuário não encontrado.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            var userInterface = UserPipe(user);

            return Ok(new { message = "Usuário removido com sucesso!", user = userInterface});
        }

        private IUser UserPipe (User user) {
            return new IUser
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                UserOrders = user.UserOrders
            };
        }
    }
}
