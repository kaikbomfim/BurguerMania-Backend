namespace burguermania_backend.Models;
using System.ComponentModel.DataAnnotations;

public class User {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "O email do usuário é obrigatório.")]
    [EmailAddress(ErrorMessage = "O email fornecido não é válido.")]  
    public required string Email { get; set; }  

    [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
    public required string Password { get; set; }  

    public ICollection<UserOrder>? UserOrders { get; set; }
}
