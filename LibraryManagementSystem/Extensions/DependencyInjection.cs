using FluentValidation.AspNetCore;
using LibraryManagementSystem.Core.Mapping;


namespace LibraryManagementSystem.Extensions;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddSwaggerConfig();
        services.AddCorsConfig();
        services.AddPersistence(configuration);
        services.AddAutoMapperConfig();
        services.AddFluentValidationConfig();

        return services;
    }
    private static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
    private static IServiceCollection AddCorsConfig(this IServiceCollection services)
    {
        //var allowedOrigins = configuration.GetSection("AllowedOrigins").Get<string[]>();    
        //if (allowedOrigins is null || allowedOrigins.Length == 0)
        //{
        //    throw new Exception(Errors.AllowedCorsOriginsNotFound);
        //}
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin();
                // .WithOrigins(allowedOrigins);
            });
        });

        return services;
    }
    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
           ?? throw new InvalidOperationException(Errors.ConnectionStringNotFound);

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        return services;
    }
    private static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));
        return services;
    }
    private static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        return services;
    }

}
