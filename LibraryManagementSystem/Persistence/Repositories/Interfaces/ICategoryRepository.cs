namespace LibraryManagementSystem.Persistence.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<IReadOnlyList<Category>> GetListAsync();
    Task<PaginatedList<Category>> GetPagedListAsync(int pageNumber, int pageSize);
    Task<Category?> GetAsync(int id);
    Task<Category> AddAsync(Category category);
    Task<bool> UpdateAsync(int id, Category category);
    Task<bool> RemoveAsync(int id);
}
