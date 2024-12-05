namespace burguermania_backend.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Status {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do status é obrigatório.")]
    public required string Name { get; set; }  

    [JsonIgnore]
    public ICollection<Order>? Orders { get; set; }
}
