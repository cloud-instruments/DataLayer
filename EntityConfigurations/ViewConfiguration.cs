using System.Data.Entity.ModelConfiguration;

namespace DataLayer.EntityConfigurations
{
    public class ViewConfiguration : EntityTypeConfiguration<View>
    {
        ////////////////////////////////////////////////////////////
        // Constructors
        ////////////////////////////////////////////////////////////

        /// <summary>
        /// ctor
        /// </summary>
        public ViewConfiguration()
        {
            ToTable("Views");

            HasKey(e => e.Id);

            Property(e => e.Comments).HasMaxLength(500);
            Property(e => e.Name).IsRequired().HasMaxLength(256);

            HasRequired(e => e.PlotTemplate)
                .WithMany(e => e.Views)
                .HasForeignKey(e => e.PlotTemplateId);
            HasRequired(e => e.User)
                .WithMany(e => e.Views)
                .HasForeignKey(e => e.UserId);
        }
    }
}
