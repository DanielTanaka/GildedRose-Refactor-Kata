using System;

namespace GildedRose.Model
{
    public class CommonItem : IItem
    {
        private static int ItemMaximumAllowedQuality { get => 50; }

        public string Name { get; set; }
        public DateTime SellBy { get; set; }
        public int Quality { get; set; }
        public DateTime UpdateQualityLastRan { get; set; }
        public int MaximumAllowedQuality { get => ItemMaximumAllowedQuality; }
    }
}
