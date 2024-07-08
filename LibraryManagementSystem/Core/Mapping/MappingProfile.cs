namespace LibraryManagementSystem.Core.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookResponse>()
            .ForCtorParam("Category", opt => opt.MapFrom(src => src.Category!.Name))
            .ForCtorParam("CreatedOn", opt => opt.MapFrom(src => src.CreatedOn.ToString()));
        
        CreateMap<BookRequest, Book>();

        CreateMap<Category, CategoryResponse>()
             .ForCtorParam("CreatedOn", opt => opt.MapFrom(src => src.CreatedOn.ToString())); 
        CreateMap<CategoryRequest, Category>();
    }
}
