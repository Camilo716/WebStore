namespace WebStore.Models;

public class  CategoryModel
{
    public int CategoryId { get; set;}
    public string Description { get; set;}
    public bool Active { get; set;}
    public DateTime RegistrationDate { get; set;}

    public virtual ICollection<ProductModel> ProductsInCategory { get; set; }
}