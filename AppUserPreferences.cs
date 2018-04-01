using Newtonsoft.Json;

namespace DataLayer
{
    public class AppUserPreferences
    {
        internal string _ChartPreferences { get; set; }

        /// <summary>
        /// Application user indentifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Chart globla preferences
        /// </summary>
        public ChartPreferences ChartPreferences
        {
            get => _ChartPreferences == null ? null : JsonConvert.DeserializeObject<ChartPreferences>(_ChartPreferences);
            set => _ChartPreferences = JsonConvert.SerializeObject(value);
        }

        public static AppUserPreferences Default => new AppUserPreferences
        {
            ChartPreferences = new ChartPreferences
            {
                LegendShowen = false,
                PointSize = 2,
                XLineVisible = false,
                YLineVisible = true,
                FontSize = 12,
                FontFamilyName = "Verdana",
                PaletteColors = new [] {
                    "#5f8b95", "#ba4d51", "#af8a53", "#955f71", "#859666", "#7e688c", "#78b6d9", "#679ec5",
                    "#ad79ce", "#7abd5c", "#e18e92", "#b6d623", "#b7abea", "#85dbd5", "#dea484", "#f2c0b5",
                    "#70c92f", "#f8ca00", "#bd1550", "#e97f02", "#9d419c", "#7e4452", "#9ab57e", "#36a3a6" }
            }
        };

    }
}
