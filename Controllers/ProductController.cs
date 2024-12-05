using burguermania_backend.Models;
using Microsoft.AspNetCore.Mvc;
using burguermania_backend.Context;
using Microsoft.EntityFrameworkCore;

namespace burguermania_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase {
        private readonly BurguerManiaDbContext _context;

        public ProductController(BurguerManiaDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();

            if (!products.Any()) {
                return NotFound("Produtos não encontrados");
            }

            return Ok(new {message="Produtos encontrados com sucesso!", products});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult <Product>> GetProduct(int id){
            var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) {
                return NotFound("Produto não encontrado");
            }

            return Ok(new {message = "Produto encontrado com sucesso!", product});
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, new {message = "Produto criado com sucesso!", product});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product) { 
            if(id != product.Id) {
                return BadRequest("ID do produto não corresponde ao produto enviado.");
            }   

            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (existingProduct == null) {
                return NotFound("Produto não encontrado para atualização.");
            }

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new {message = "Produto atualizado com sucesso!", product});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id){
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null){
                return NotFound("Produto não encontrado.");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(new {message = "Produto removido com sucesso!", product});
        }
    }
}