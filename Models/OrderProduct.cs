namespace burguermania_backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderProduct {
    [Key]
    public int Id { get; set; }

    public int Quantity { get; set; }
    
    [ForeignKey("Product")]
    public int ProductId { get; set; }  // Relacionamento com Product (Produto)
    public Product? Product { get; set; }
    
    [ForeignKey("Order")]
    public int OrderId { get; set; }  // Relacionamento com Order (Pedido)
    public Order? Order { get; set; }
}
