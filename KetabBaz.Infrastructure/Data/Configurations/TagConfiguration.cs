namespace KetabBaz.Infrastructure.Data.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> tag)
    {
        tag.Property(t => t.Title)
            .HasMaxLength(100)
            .IsRequired();

        tag.Property(t => t.Slug)
            .HasMaxLength(100)
            .IsRequired();

        tag.HasIndex(t => t.Slug)
            .IsUnique();
    }
}
