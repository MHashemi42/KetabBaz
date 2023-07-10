namespace KetabBaz.Core.Entities;

public class View : EntityBase
{
    public int BookId { get; set; }
    public IPAddress IP { get; set; }

    public Book Book { get; set; }
}
