using System.ComponentModel.DataAnnotations;

namespace clase7.ViewModels;

public class MovementCreateVM
{
    public int InvoiceNumber { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
    public int GameId { get; set; }
}