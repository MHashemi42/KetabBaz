namespace KetabBaz.Core.Interfaces;

public interface IPublisherService
{
    Task<IEnumerable<PublisherDto>> GetPublishersAsync();
}
