namespace WebStore.Models;

public class SaleModel
{
    public int SaleId { get; set; }

    public int TotalProducts { get; set;}
    public double  TotalAmmount { get; set;}
    public DateTime SaleDate { get; set; }

    public string  Contact { get; set;}
    public int PhoneNumber { get; set;}
    public string Adress { get; set;}

    public int ClientId { get; set; }
    public string TransactionId { get; set; }
}
