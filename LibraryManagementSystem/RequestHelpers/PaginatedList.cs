namespace LibraryManagementSystem.RequestHelpers;

public class PaginatedList<T>
{
    public PaginatedList(int totalCount, int pageNumber, int pageSize, List<T> items)
    {
        Data = items;
        TotalCount = totalCount;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
    public int TotalCount { get; }
    public int PageNumber { get; }
    public int PageSize { get; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public List<T> Data { get; }
  
}
