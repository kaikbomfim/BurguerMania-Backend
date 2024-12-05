using burguermania_backend.Models;
using Microsoft.AspNetCore.Mvc;
using burguermania_backend.Context;
using Microsoft.EntityFrameworkCore;

namespace burguermania_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {
        private readonly BurguerManiaDbContext _context;

        public OrderController(BurguerManiaDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders() {
            var orders = await _context.Orders.
                Include(o => o.Status).
                Include(o => o.OrderProducts).
                Include(o => o.UserOrders).ToListAsync();

            if (!orders.Any()) {
                return NotFound("Pedidos não encontrados");
            }

            return Ok(new { message = "Pedidos encontrados com sucesso!", orders });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id) {
            var order = await _context.Orders.
                Include(o => o.Status).
                Include(o => o.OrderProducts).
                Include(o => o.UserOrders).FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) {
                return NotFound("Pedido não encontrado");
            }

            return Ok(new { message = "Pedido encontrado com sucesso!", order });
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, new { message = "Pedido criado com sucesso!", order});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order) {
            if (id != order.Id) {
                return BadRequest("ID do pedido não corresponde ao pedido enviado.");
            }

            var existingOrder = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (existingOrder == null) {
                return NotFound("Pedido não encontrado para atualização.");
            }

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Pedido atualizado com sucesso!", order });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id) {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) {
                return NotFound("Pedido não encontrado.");
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Pedido removido com sucesso!", order });
        }
    }
}
