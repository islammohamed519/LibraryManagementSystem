namespace LibraryManagementSystem.Persistence.Repositories;

public sealed class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;
    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<Book>> GetPagedListAsync(int pageNumber, int pageSize)
    {
        var query = _context.Books
            .Include(b=>b.Category)
            .AsNoTracking()
            .AsQueryable();

        var totalCount = await query.CountAsync();
        var books = await query.Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return new PaginatedList<Book>(totalCount, pageNumber, pageSize, books);
    }
    public async Task<IReadOnlyList<Book>> GetListAsync()
    {
        return await _context.Books
            .Include(b => b.Category)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<Book?> GetAsync(int id)
    {
        return await _context.Books
            .Include(b=>b.Category)
            .FirstOrDefaultAsync(b=>b.BookId == id);
    }
    public async Task<Book> AddAsync(Book book)
    {
       await _context.Books.AddAsync(book);
       await _context.SaveChangesAsync();
       return book;
    }
    public async Task<bool> UpdateAsync(int id, Book book)
    {
        var currentBook = await _context.Books.FindAsync(id);
        if(currentBook is null || currentBook.IsDeleted)
            return false;

        UpdateBookDetails(currentBook, book);
        await _context.SaveChangesAsync();

        return true;
    }
    public async Task<bool> RemoveAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book is null || book.IsDeleted)
            return false;

        book.IsDeleted = true;
        await _context.SaveChangesAsync();
        return true;
    }
    private void UpdateBookDetails(Book currentBook, Book newBook)
    {
        currentBook.Name = newBook.Name;
        currentBook.Description = newBook.Description;
        currentBook.Author = newBook.Author;
        currentBook.Price = newBook.Price;
        currentBook.Stock = newBook.Stock;
        currentBook.CategoryId = newBook.CategoryId;
        currentBook.LastUpdatedOn = DateTime.Now;
    }
}
