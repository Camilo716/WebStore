namespace WebStore.Models;

public class ProductModel
{
    public int ProductId { get; set;}
    public string Name { get; set;}
    public string Description { get; set;}
    

    public double Price { get; set;}
    public double Stock { get; set;}

    public string ImgRoute { get; set;}
    public string ImgName { get; set;}

    public bool Active { get; set;} 
    public DateTime RegistrationDate { get; set;}

    public int BrandId { get; set;}
    public int CategoryId { get; set;}

    public CategoryModel Category { get; set;}
    public BrandModel Brand { get; set;}
}