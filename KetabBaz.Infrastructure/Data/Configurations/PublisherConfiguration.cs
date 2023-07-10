namespace KetabBaz.Infrastructure.Data.Configurations;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> publisher)
    {
        publisher.Property(p => p.Title)
            .HasMaxLength(100)
            .IsRequired();

        publisher.Property(p => p.ImageUrl)
            .HasMaxLength(100);
    }
}
