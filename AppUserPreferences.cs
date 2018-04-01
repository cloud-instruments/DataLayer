/*
Copyright(c) <2018> <University of Washington>
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

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
