namespace DataLayer
{
    public class DataPoint
    {
        public int ProjectId { get; set; }

        public int Index { get; set; }
        public int CycleIndex { get; set; }
        public byte CycleStep { get; set; }

        public double Time { get; set; }
        public double? Current { get; set; }
        public double? Voltage { get; set; }
        public double? Capacity { get; set; }
        public double? Energy { get; set; }
        public double? Power { get; set; }
        public double? Temperature { get; set; }
    }
}
