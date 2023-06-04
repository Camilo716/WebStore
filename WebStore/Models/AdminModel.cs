namespace WebStore.Models;

public class AdminModel
{
    public int AdminId { get; set; }
    
    public string Names { get; set; }
    public string Lastnames { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }

    public bool Restore { get ; set; }
    public bool Active { get ; set; }
}
