namespace DataLayer
{
    using Newtonsoft.Json;

    public class Cycle
    {
        /// <summary>
        /// For EF and SqlBulkCopy, do not use directly
        /// </summary>
        public string StatisticMetaDataInternal { get; set; }

        public int ProjectId { get; set; }

        public int Index { get; set; }
        public int FirstPointIndex { get; set; }
        public int PointCount { get; set; }

        public double? EndCurrent { get; set; }
        public double? DischargeEndCurrent { get; set; }
        public double? MidVoltage { get; set; }
        public double? EndVoltage { get; set; }
        public double? DischargeEndVoltage { get; set; }
        public double? ChargeCapacity { get; set; }
        public double? DischargeCapacity { get; set; }
        public double? ChargeCapacityRetention { get; set; }
        public double? DischargeCapacityRetention { get; set; }
        public double? DischargeEnergy { get; set; }
        public double? ChargeEnergy { get; set; }
        public double? Power { get; set; }
        public double? DischargePower { get; set; }
        public double? Temperature { get; set; }

        /// <summary>
        /// Gets or sets voltage value for the last rest step in the cycle
        /// </summary>
        public double? EndRestVoltage { get; set; }

        /// <summary>
        /// Gets or sets voltage value for the first charge step in the cycle
        /// </summary>
        public double? StartChargeVoltage { get; set; }

        /// <summary>
        /// Gets or sets voltage value for the first discharge step in the cycle
        /// </summary>
        public double? StartDischargeVoltage { get; set; }

        /// <summary>
        /// Gets or sets current for the first charge step in the cycle
        /// </summary>
        public double? StartCurrent { get; set; }

        /// <summary>
        /// Gets or sets current for the first discharge step in the cycle
        /// </summary>
        public double? StartDischargeCurrent { get; set; }

        /// <summary>
        /// Gets or sets charge resistance for the cycle
        /// </summary>
        public double? ResistanceOhms { get; set; }

        /// <summary>
        /// Gets or sets discharge resistance for the cycle
        /// </summary>
        public double? DischargeResistance { get; set; }

        public StatisticMetaData StatisticMetaData
        {
            get => string.IsNullOrEmpty(StatisticMetaDataInternal) ? null : JsonConvert.DeserializeObject<StatisticMetaData>(StatisticMetaDataInternal);
            set => StatisticMetaDataInternal = JsonConvert.SerializeObject(value);
        }
    }

    public class StatisticMetaData
    {
        public double? EndCurrentStdDev { get; set; }
        public double? MidVoltageStdDev { get; set; }
        public double? EndVoltageStdDev { get; set; }
        public double? DischargeEndCurrentStdDev { get; set; }
        public double? DischargeEndVoltageStdDev { get; set; }
        public double? ChargeCapacityStdDev { get; set; }
        public double? DischargeCapacityStdDev { get; set; }
        public double? DischargeEnergyStdDev { get; set; }
        public double? ChargeEnergyStdDev { get; set; }
        public double? PowerStdDev { get; set; }
        public double? DischargePowerStdDev { get; set; }
        public double? ResistanceOhmsStdDev { get; set; }
        public double? DischargeResistanceStdDev { get; set; }
        public double? CoulombicEfficiencyStdDev { get; set; }
        public double? CoulombicEfficiencyAverage { get; set; }
        public double? ChargeCapacityRetentionStdDev { get; set; }
        public double? DischargeCapacityRetentionStdDev { get; set; }
    }
}
