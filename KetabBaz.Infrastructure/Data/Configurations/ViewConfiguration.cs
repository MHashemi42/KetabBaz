namespace KetabBaz.Infrastructure.Data.Configurations;

public class ViewConfiguration : IEntityTypeConfiguration<View>
{
    public void Configure(EntityTypeBuilder<View> view)
    {
        view.HasOne(v => v.Book)
               .WithMany(b => b.Views)
               .HasForeignKey(v => v.BookId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
