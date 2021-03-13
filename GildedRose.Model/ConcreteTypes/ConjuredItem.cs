using System;

namespace GildedRose.Model
{
    public class ConjuredItem : IDecreasingQualityItem
    {
        private static int ItemMaximumAllowedQuality { get => 50; }
        private static int ItemQualityDegradationRate { get => 2 * CommonItem.ItemInitialDegradationRate; }

        public string Name { get; set; }
        public DateTime SellBy { get; set; }
        public int Quality { get; set; }
        public DateTime LastQualityCheckUp { get; set; }
        public int MaximumAllowedQuality { get => ItemMaximumAllowedQuality; }
        public int QualityDegradationRate { get => ItemQualityDegradationRate; }
    }
}
