namespace WebStore.Models;

public class Client
{
    int ClientId { get; set;}
    string Names { get; set;}
    string Lastnames { get; set;}
    string Mail { get; set;}
    string Password { get; set;}
    bool Restore { get; set;}
    DateTime RegistrationDate { get; set;}
}