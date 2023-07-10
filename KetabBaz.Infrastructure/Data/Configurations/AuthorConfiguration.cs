namespace KetabBaz.Infrastructure.Data.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> author)
    {
        author.Property(a => a.Name)
            .HasMaxLength(100)
            .IsRequired();

        author.Property(a => a.Bio)
            .HasMaxLength(2000);

        author.Property(a => a.ImageUrl)
            .HasMaxLength(100);
    }
}
