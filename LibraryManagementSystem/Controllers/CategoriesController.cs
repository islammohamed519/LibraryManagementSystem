namespace LibraryManagementSystem.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoriesController(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    
    //Get-All
    [HttpGet]
    [ProducesResponseType(typeof(PaginatedList<CategoryResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginatedList<CategoryResponse>>> GetCategoriesList([FromQuery] PaginationParams paginationParams)
    {
        var paginatedCategories = await _categoryRepository.GetPagedListAsync(paginationParams.PageNumber, paginationParams.PageSize);
        var paginatedCategoriesResponse = new PaginatedList<CategoryResponse>(
            paginatedCategories.TotalCount,
            paginatedCategories.PageNumber,
            paginatedCategories.PageSize,
            _mapper.Map<List<CategoryResponse>>(paginatedCategories.Data));

        return Ok(paginatedCategoriesResponse);
    }
    
    //Get-By-Id
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<CategoryResponse>> GetCategory([FromRoute] int id)
    {
        var category = await _categoryRepository.GetAsync(id);
        if (category is null)
            return NotFound();
        return Ok(_mapper.Map<CategoryResponse>(category));
    }
    
    //Add-Category
    [HttpPost]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> AddCategory([FromBody] CategoryRequest request)
    {
        var newCategory = await _categoryRepository.AddAsync(_mapper.Map<Category>(request));
        var category = await _categoryRepository.GetAsync(newCategory.CategoryId);
        var categoryResponse = _mapper.Map<CategoryResponse>(category);
        return CreatedAtAction(nameof(GetCategory), new { id = newCategory.CategoryId }, categoryResponse);
    }
    
    //Edit-Category
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryRequest request)
    {
        var isUpdated = await _categoryRepository.UpdateAsync(id, _mapper.Map<Category>(request));
        var category = await _categoryRepository.GetAsync(id);
        return !isUpdated
            ? NotFound()
            : NoContent();
    }
    
    //Delete-Category
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id)
    {
        var isDeleted = await _categoryRepository.RemoveAsync(id);
        return !isDeleted
            ? NotFound()
            : NoContent();
    }
}
