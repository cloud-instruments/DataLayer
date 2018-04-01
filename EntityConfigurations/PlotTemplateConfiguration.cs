using System.Data.Entity.ModelConfiguration;

namespace DataLayer.EntityConfigurations
{
    public class PlotTemplateConfiguration : EntityTypeConfiguration<PlotTemplate>
    {
        ////////////////////////////////////////////////////////////
        // Constructors
        ////////////////////////////////////////////////////////////

        /// <summary>
        /// ctor
        /// </summary>
        public PlotTemplateConfiguration()
        {
            ToTable("PlotTemplates");

            HasKey(e => e.Id);

            Property(e => e.Name).IsRequired().HasMaxLength(256);

            HasRequired(e => e.User)
                .WithMany(e => e.PlotTemplates)
                .HasForeignKey(e => e.UserId);

            Ignore(t => t.OwnerName);
        }
    }
}
