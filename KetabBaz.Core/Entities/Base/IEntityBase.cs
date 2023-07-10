namespace KetabBaz.Core.Entities.Base;

public interface IEntityBase
{
    public int Id { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateUpdated { get; set; }
}
