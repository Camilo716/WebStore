namespace WebStore.Models;

public class ClientModel
{
    public int ClientId { get; set;}
    public string Names { get; set;}
    public string Lastnames { get; set;}
    public string Mail { get; set;}
    public string Password { get; set;}
    public bool Restore { get; set;}
    public DateTime RegistrationDate { get; set;}

    public ClientModel()
    {
        Restore = true;
        RegistrationDate = DateTime.Now;
    }
}