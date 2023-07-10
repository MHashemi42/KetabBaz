namespace KetabBaz.Core.Interfaces;

public interface ISlideshowService
{
    Task<IList<SlideshowDto>> GetSlideshows(int count);
}
