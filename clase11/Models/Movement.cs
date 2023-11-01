using clase7.Utils;

namespace clase7.Models;

public class Movement
{
    public int Id { get; set; }
    public int InvoiceNumber { get; set; }
    public DateTime Date { get; set; }
    public MovementType TypeM { get; set; }
    public int Quantity { get; set; }
    public int GameId { get; set; }
    public virtual Game Game { get; set; }
}
