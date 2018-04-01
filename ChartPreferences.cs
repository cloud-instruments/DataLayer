namespace DataLayer
{
    public class ChartPreferences
    {
        /// <summary>
        /// Indicates if legend should be shown
        /// </summary>
        public bool LegendShowen { get; set; }
        /// <summary>
        /// Gets or sets point size on the chart
        /// </summary>
        public int PointSize { get; set; }
        /// <summary>
        /// Indicates if grid line should be shown for X axis
        /// </summary>
        public bool XLineVisible { get; set; }
        /// <summary>
        /// Indicates if grid line should be shown for Y axis
        /// </summary>
        public bool YLineVisible { get; set; }
        /// <summary>
        /// Gets or sets font size for labels on the chart
        /// </summary>
        public int FontSize { get; set; }
        /// <summary>
        /// Gets or sets font family for labels on the chart
        /// </summary>
        public string FontFamilyName { get; set; }
        /// <summary>
        /// Gets or sets palette collors for the chart lines
        /// </summary>
        public string[] PaletteColors { get; set; }
    }
}