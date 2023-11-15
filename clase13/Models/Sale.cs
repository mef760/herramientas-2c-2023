namespace clase13.Models;

public class Sale 
{
    public int Id { get; set; }
    public int Number { get; set; }
    public DateTime DateSale { get; set; }
    public string Description { get; set; }

    public int ClientId { get; set; }
    public virtual Client Client { get; set; }
}