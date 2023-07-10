namespace KetabBaz.Core.Interfaces;

public interface ISlideshowRepository : IRepository<Slideshow>
{
    Task<IList<Slideshow>> GetSlideshows(int count);
}
