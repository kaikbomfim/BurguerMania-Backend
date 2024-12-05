namespace burguermania_backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class UserOrder {
    [Key]
    public int Id { get; set; }

    [ForeignKey("User")]
    public required int UserId { get; set; }  // Relacionamento com User (Usuário)
    
    [JsonIgnore]
    public User? User { get; set; }

    [ForeignKey("Order")]
    public required int OrderId { get; set; }  // Relacionamento com Order (Pedido)
    
    [JsonIgnore]
    public Order? Order { get; set; }
}
