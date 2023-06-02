namespace WebStore.Models;

public class ShoppingCartModel
{
    public int ShoppingCartId { get; set; }
    public int ClientId { get; set; }
    public int ProductId { get; set; }
    public int Amount { get; set; }
}
