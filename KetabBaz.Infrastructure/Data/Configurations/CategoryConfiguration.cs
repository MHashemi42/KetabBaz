namespace KetabBaz.Infrastructure.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> category)
    {
        category.Property(c => c.Title)
            .HasMaxLength(100)
            .IsRequired();
    }
}
