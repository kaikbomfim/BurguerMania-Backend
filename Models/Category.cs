namespace burguermania_backend.Models;
using System.ComponentModel.DataAnnotations;

public class Category {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "A descrição da categoria é obrigatória.")]
    public required string Description { get; set; }

    [Required(ErrorMessage = "O caminho da imagem da categoria é obrigatório.")]
    public required string PathImage { get; set; }  

    public ICollection<Product>? Products { get; set; } = new List<Product>();
}
