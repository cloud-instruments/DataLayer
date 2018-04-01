using System.Data.Entity.ModelConfiguration;

namespace DataLayer.EntityConfigurations
{
    public class CycleConfiguration : EntityTypeConfiguration<Cycle>
    {
        ////////////////////////////////////////////////////////////
        // Constructors
        ////////////////////////////////////////////////////////////

        /// <summary>
        /// ctor
        /// </summary>
        public CycleConfiguration()
        {
            ToTable("Cycles");

            HasKey(e => new { e.ProjectId, e.Index });

            Property(e => e.StatisticMetaDataInternal)
                .HasColumnName("StatisticMetaData")
                .IsOptional();

            Ignore(e => e.StatisticMetaData);
        }
    }
}
