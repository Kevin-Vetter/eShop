namespace DAL.Model;

public class Order
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
    public int Amount { get; set; }
    public ICollection<Product> Products { get; set; }
}
