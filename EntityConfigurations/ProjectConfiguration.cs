using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataLayer.EntityConfigurations
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        ////////////////////////////////////////////////////////////
        // Constructors
        ////////////////////////////////////////////////////////////

        /// <summary>
        /// ctor
        /// </summary>
        public ProjectConfiguration()
        {
            ToTable("Projects");

            HasKey(e => e.Id);

            Property(e => e.Name).IsRequired().HasMaxLength(256);
            Property(e => e.FileName).IsRequired().HasMaxLength(256);
            Property(e => e.InternalFileName).HasMaxLength(256);
            Property(e => e.TestName).HasMaxLength(256);
            Property(e => e.TestType).HasMaxLength(256);
            Property(e => e.Channel).HasMaxLength(256);
            Property(e => e.Tag).HasMaxLength(256);
            Property(e => e.Comments).HasMaxLength(256);
            Property(e => e.Error).HasMaxLength(256);
            Property(e => e.IsAveragePlot).IsRequired();
            Property(e => e.IsPartialGathering).IsRequired();

            HasRequired(e => e.User)
                .WithMany(e => e.Projects)
                .HasForeignKey(e => e.UserId);

            Ignore(t => t.OwnerName);
        }
    }
}
