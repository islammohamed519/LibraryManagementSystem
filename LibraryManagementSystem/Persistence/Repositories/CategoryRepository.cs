namespace LibraryManagementSystem.Persistence.Repositories;

public sealed class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<Category>> GetPagedListAsync(int pageNumber, int pageSize)
    {
        var query = _context.Categories
                .AsNoTracking()
                .AsQueryable();

        var totalCount = await query.CountAsync();
        var categories = await query.Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return new PaginatedList<Category>(totalCount, pageNumber, pageSize, categories);
    }
    public async Task<IReadOnlyList<Category>> GetListAsync()
    {
        return await _context.Categories.AsNoTracking().ToListAsync();
    }
    public async Task<Category?> GetAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }
    public async Task<Category> AddAsync(Category category)
    {
       await _context.Categories.AddAsync(category);
       await _context.SaveChangesAsync();
        return category;
    }
    public async Task<bool> UpdateAsync(int id, Category category)
    {
        var currentCategory = await _context.Categories.FindAsync(id);
        if(currentCategory is null || currentCategory.IsDeleted)
            return false;

        UpdateCategoryDetails(currentCategory, category);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> RemoveAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category is null || category.IsDeleted)
            return false;

        category.IsDeleted = true;
        await _context.SaveChangesAsync();
        return true;
    }
    private void UpdateCategoryDetails(Category currentCategory, Category newCategory)
    {
        currentCategory.Name = newCategory.Name;
        currentCategory.Description = newCategory.Description;
        currentCategory.LastUpdatedOn = DateTime.Now;
    }
 
}
