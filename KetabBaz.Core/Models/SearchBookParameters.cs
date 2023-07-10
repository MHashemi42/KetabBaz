namespace KetabBaz.Core.Models;

public class SearchBookParameters
{
    public string Query { get; set; }
    public SortBookType SortBy { get; set; }
    public string Category { get; set; }
    public string Publisher { get; set; }

    private int _pageNumber = 1;
    public int PageNumber 
    {
        get
        {
            return _pageNumber;
        }
        set
        {
            _pageNumber = value < 1 ? 1 : value;
        }
    }

    private int _pageSize = 15;
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = value < 1 ? 15 : value;
        }
    }
}
