namespace DevFreela.Infrastructure.Persistence.Models;

public class PaginationResult<T>
{
    public PaginationResult()
    {
        
    }

    public PaginationResult(int page, int totalPages, int pageSizes, int itemsCount, List<T> data)
    {
        Page = page;
        TotalPages = totalPages;
        PageSize = pageSizes;
        ItemsCount = itemsCount;
        Data = data;
    }

    public int Page { get; set; }
    public int TotalPages { get; set; }
    public int  PageSize { get; set; }
    public int ItemsCount { get; set; }
    public List<T> Data { get; set; }
}