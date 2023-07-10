namespace KetabBaz.Infrastructure.Data.Configurations;

public class BannerConfiguration : IEntityTypeConfiguration<Banner>
{
    public void Configure(EntityTypeBuilder<Banner> banner)
    {
        banner.Property(b => b.ImageUrl)
            .HasMaxLength(200)
            .IsRequired();

        banner.Property(b => b.Url)
            .HasMaxLength(200)
            .IsRequired();
    }
}
