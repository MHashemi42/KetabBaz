namespace KetabBaz.Infrastructure.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> book)
    {
        book.Property(b => b.OriginalTitle)
            .HasMaxLength(100)
            .IsRequired();

        book.Property(b => b.TranslatedTitle)
            .HasMaxLength(100)
            .IsRequired();

        book.Property(b => b.Description)
            .HasMaxLength(2000);

        book.Property(b => b.Isbn)
            .HasMaxLength(13)
            .IsRequired();

        book.Property(b => b.ImageUrl)
            .HasMaxLength(100);

        book.Property(b => b.Size)
            .HasMaxLength(20);

        book.Property(b => b.Cover)
            .HasMaxLength(20);

        book.Property(b => b.PublishDate)
            .HasColumnType("date");

        book.HasOne(b => b.Author)
               .WithMany(b => b.WrittenBooks)
               .HasForeignKey(b => b.AuthorId)
               .OnDelete(DeleteBehavior.Cascade);

        book.HasOne(b => b.Translator)
               .WithMany(b => b.TranslatedBooks)
               .HasForeignKey(b => b.TranslatorId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
