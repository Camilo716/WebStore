namespace WebStore.Models;

public class SaleDetailsModel
{
    public int SaleDetailsId { get; set;}        

    public int Amount { get; set;}
    public double Total { get; set;}

    public int SaleId { get; set;}
    public int ProductId { get; set;}
    public SaleModel Sale { get; set; }
    public ProductModel Product { get; set;}
}
