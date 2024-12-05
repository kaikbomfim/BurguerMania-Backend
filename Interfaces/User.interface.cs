using burguermania_backend.Models;

namespace burguermania_backend.Interfaces;

public class IUser {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    public ICollection<UserOrder>? UserOrders { get; set; }
}