

namespace LibraryManagementSystem.Persistence.Repositories.Interfaces;

public interface IBookRepository
{
    Task<PaginatedList<Book>> GetPagedListAsync(int pageNumber, int pageSize);
    Task<IReadOnlyList<Book>> GetListAsync();
    Task<Book?> GetAsync(int id);
    Task<Book> AddAsync(Book book);
    Task<bool> UpdateAsync(int id, Book book);
    Task<bool> RemoveAsync(int id);

}
