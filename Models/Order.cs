namespace burguermania_backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Order {
    [Key]
    public int Id { get; set; }

    [ForeignKey("Status")]
    public required int StatusId { get; set; }  // Relacionamento com Status
    public Status? Status { get; set; }
    
    [Required(ErrorMessage = "O valor do pedido é obrigatório.")]
    public required float Value { get; set; }  

    public string? Observation { get; set; }

    [JsonIgnore]
    public ICollection<OrderProduct>? OrderProducts { get; set; }
    
    [JsonIgnore]
    public ICollection<UserOrder>? UserOrders { get; set; }
}
