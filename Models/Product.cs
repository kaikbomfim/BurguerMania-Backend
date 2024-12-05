namespace burguermania_backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Product {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "O caminho da imagem do produto é obrigatório.")]
    public required string PathImage { get; set; }  

    [Required(ErrorMessage = "O preço do produto é obrigatório.")]
    public required double Price { get; set; }  

    [Required(ErrorMessage = "A descrição curta do produto é obrigatória.")]
    public required string BaseDescription { get; set; }

    [Required(ErrorMessage = "A descrição completa do produto é obrigatória.")]
    public required string FullDescription { get; set; }

    [ForeignKey("Category")]
    public required int CategoryId { get; set; }  

    [JsonIgnore]
    public Category? Category { get; set; }

    public ICollection<OrderProduct>? OrderProducts { get; set; }
}
