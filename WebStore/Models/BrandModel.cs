namespace WebStore.Models;

public class BrandModel
{
    public int BrandId { get; set;}
    public string Description { get; set;}
    public bool Active { get; set;}
    public DateTime RegistrationDate { get; set;}

    public virtual ICollection<ProductModel> ProductsInBrand { get; set;}
}
