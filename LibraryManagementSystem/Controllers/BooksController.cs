namespace LibraryManagementSystem.Controllers;


[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    public BooksController(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    
    // Get-All
    [HttpGet]
    [ProducesResponseType(typeof(PaginatedList<BookResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginatedList<BookResponse>>> GetBooksList([FromQuery] PaginationParams paginationParams)
    {
        var paginatedBooks = await _bookRepository.GetPagedListAsync(paginationParams.PageNumber, paginationParams.PageSize);

        var paginatedBooksResponse = new PaginatedList<BookResponse>(
            paginatedBooks.TotalCount,
            paginatedBooks.PageNumber,
            paginatedBooks.PageSize,
            _mapper.Map<List<BookResponse>>(paginatedBooks.Data));

        return Ok(paginatedBooksResponse);
    }
    
    // Get-By-Id
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BookResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<BookResponse>> GetBook([FromRoute] int id)
    {
        var book = await _bookRepository.GetAsync(id);

        return book is null
            ? NotFound()   
            : Ok(_mapper.Map<BookResponse>(book));
    }
    
    //Add-Book
    [HttpPost]
    [ProducesResponseType(typeof(BookResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> AddBook([FromBody] BookRequest request)
    {
        var newBook = await _bookRepository.AddAsync(_mapper.Map<Book>(request));
        var book = await _bookRepository.GetAsync(newBook.BookId);
        var bookResponse = _mapper.Map<BookResponse>(book);
        return CreatedAtAction(nameof(GetBook), new { id = newBook.BookId }, bookResponse);
    }
    
    //Edit-Book
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] BookRequest request)
    {
        var isUpdated = await _bookRepository.UpdateAsync(id, _mapper.Map<Book>(request));
        var book = await _bookRepository.GetAsync(id);
        return !isUpdated
            ? NotFound()
            : NoContent();
    }
    
    //Delete-Book
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBook([FromRoute] int id)
    {
        var isDeleted = await _bookRepository.RemoveAsync(id);
        return !isDeleted
            ? NotFound()
            : NoContent();
    }

}
