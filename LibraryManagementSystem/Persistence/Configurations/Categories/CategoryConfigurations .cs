namespace LibraryManagementSystem.Persistence.Configurations.Categories;

public class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(e => e.Name)
               .IsRequired()
               .HasMaxLength(250);
        builder.Property(e => e.Description)
               .IsRequired()
               .HasMaxLength(1000);

        builder.HasQueryFilter(e => !e.IsDeleted);
    }
}
