namespace KetabBaz.Infrastructure.Data.Configurations;

public class CarouselConfiguration : IEntityTypeConfiguration<Carousel>
{
    public void Configure(EntityTypeBuilder<Carousel> carousel)
    {
        carousel.Property(c => c.ImageUrl)
            .HasMaxLength(100)
            .IsRequired();

        carousel.Property(c => c.Url)
            .HasMaxLength(100)
            .IsRequired();
    }
}
