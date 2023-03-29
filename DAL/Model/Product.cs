namespace DAL.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public Brand Brand { get; set; }
    public int BrandId { get; set; }
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public int Popularity { get; set; }
    public Image Thumbnail { get; set; }
    public int ImageId { get; set; }

    public ICollection<Order> Orders { get; set; }
}
