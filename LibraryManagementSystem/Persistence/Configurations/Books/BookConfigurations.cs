namespace LibraryManagementSystem.Persistence.Configurations.Books;

public class BookConfigurations : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(e => e.Name).HasMaxLength(250);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Author).HasMaxLength(250);
        builder.Property(e => e.Price).HasColumnType("decimal(18,2)");

        builder.HasQueryFilter(e => !e.IsDeleted);

    }
}
