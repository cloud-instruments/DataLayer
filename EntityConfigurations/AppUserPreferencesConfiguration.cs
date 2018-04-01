using System.Data.Entity.ModelConfiguration;

namespace DataLayer.EntityConfigurations
{
    public class AppUserPreferencesConfiguration : EntityTypeConfiguration<AppUserPreferences>
    {
        ////////////////////////////////////////////////////////////
        // Constructors
        ////////////////////////////////////////////////////////////

        /// <summary>
        /// ctor
        /// </summary>
        public AppUserPreferencesConfiguration()
        {
            ToTable("AppUserPreferences");

            HasKey(e => e.Id);

            Property(e => e._ChartPreferences)
                .HasColumnName("ChartPreferences")
                .IsRequired();

            Ignore(e => e.ChartPreferences);
        }
    }
}
