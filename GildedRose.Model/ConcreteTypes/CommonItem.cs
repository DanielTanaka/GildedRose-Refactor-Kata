using System;

namespace GildedRose.Model
{
    public class CommonItem : IDecreasingQualityItem
    {
        private static int ItemMaximumAllowedQuality { get => 50; }
        internal static int ItemInitialDegradationRate { get => 1; }

        public string Name { get; set; }
        public DateTime SellBy { get; set; }
        public int Quality { get; set; }
        public DateTime LastQualityCheckUp { get; set; }
        public int MaximumAllowedQuality { get => ItemMaximumAllowedQuality; }
        public int QualityDegradationRate { get => ItemInitialDegradationRate; }
    }
}
