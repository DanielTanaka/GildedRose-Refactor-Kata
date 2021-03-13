using System;

namespace GildedRose.Model
{
    public class LegendaryItem : ISteadyQualityItem
    {
        private static int ItemMaximumAllowedQuality { get => 80; }

        public string Name { get; set; }
        public DateTime SellBy { get; set; }
        public int Quality { get; set; }
        public DateTime LastQualityCheckUp { get; set; }
        public int MaximumAllowedQuality { get => ItemMaximumAllowedQuality; }
    }
}
