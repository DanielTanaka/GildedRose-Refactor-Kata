using System;

namespace GildedRose.Model
{
    public class AgedItem : IIncreasingQualityItem
    {
        private static int ItemMaximumAllowedQuality { get => 50; }
        private static int ItemQualityIncreasingRate { get => 1; }

        public string Name { get; set; }
        public DateTime SellBy { get; set; }
        public int Quality { get; set; }
        public DateTime LastQualityCheckUp { get; set; }
        public int MaximumAllowedQuality { get => ItemMaximumAllowedQuality; }
        public int QualityIncreasingRate { get => ItemQualityIncreasingRate; }
    }
}
