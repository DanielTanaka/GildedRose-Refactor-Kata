using System;

namespace GildedRose.Model
{
    public class BackstagePassItem : ICompetitiveQualityItem
    {
        private static int ItemMaximumAllowedQuality { get => 50; }
        private static int ItemQualityDegradationRate { get => 1; }

        public string Name { get; set; }
        public DateTime SellBy { get; set; }
        public int Quality { get; set; }
        public DateTime LastQualityCheckUp { get; set; }
        public int MaximumAllowedQuality { get => ItemMaximumAllowedQuality; }
        public int QualityDegradationRate { get => ItemQualityDegradationRate; }
    }
}
