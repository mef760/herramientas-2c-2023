namespace clase7.Models;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int? SalePersonId { get; set; }

    public virtual Person SalePerson { get; set;}
}