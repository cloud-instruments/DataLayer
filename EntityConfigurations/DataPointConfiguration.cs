using System.Data.Entity.ModelConfiguration;

namespace DataLayer.EntityConfigurations
{
    public class DataPointConfiguration : EntityTypeConfiguration<DataPoint>
    {
        ////////////////////////////////////////////////////////////
        // Constructors
        ////////////////////////////////////////////////////////////

        /// <summary>
        /// ctor
        /// </summary>
        public DataPointConfiguration()
        {
            ToTable("DataPoints");

            HasKey(e => new { e.ProjectId, e.Index });
        }
    }
}
