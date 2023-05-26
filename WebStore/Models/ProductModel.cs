namespace WebStore.Models;

public class ProductModel
{
    int ProductId { get; set;}
    string Name { get; set;}
    string Description { get; set;}
    
    int BrandId { get; set;}
    int CategoryId { get; set;}

    double Price { get; set;}
    double Stock { get; set;}

    string ImgRoute { get; set;}
    string ImgName { get; set;}

    bool Active { get; set;} 
    DateTime RegistrationDate { get; set;}
}