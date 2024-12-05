using burguermania_backend.Models;
using Microsoft.AspNetCore.Mvc;
using burguermania_backend.Context;
using Microsoft.EntityFrameworkCore;

namespace burguermania_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase {
        private readonly BurguerManiaDbContext _context;

        public CategoryController(BurguerManiaDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories() {
            var categories = await _context.Categories.Include(p => p.Products).ToListAsync();

            if (!categories.Any()) {
                return NotFound("Categorias não encontradas");
            }

            return Ok(new {message = "Categorias encontradas com sucesso!", categories});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id) {
            var category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) {
                return NotFound("Categoria não encontrada");
            }

            return Ok(new { message = "Categoria encontrada com sucesso!", category });
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, new {message = "Categoria criada com sucesso!", category});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category) {
            if (id != category.Id) {
                return BadRequest("ID da categoria não corresponde à categoria enviada.");
            }

            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCategory == null) {
                return NotFound("Categoria não encontrada para atualização.");
            }

            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new {message = "Categoria atualizada com sucesso!", category}); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id) {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) {
                return NotFound("Categoria não encontrada.");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Ok(new {message = "Categoria removida com sucesso!", category}); 
        }
    }
}
