using System;

namespace GildedRose.Model
{
    public class ConjuredItem : IItem
    {
        private static int ItemMaximumAllowedQuality { get => 50; }
        private static int ItemInitialDegradationRate { get => 2 * CommonItem.ItemInitialDegradationRate; }
        private static int ItemPastSellByDateDegradationRate { get => 2 * CommonItem.ItemPastSellByDateDegradationRate; }

        public string Name { get; set; }
        public DateTime SellBy { get; set; }
        public int Quality { get; set; }
        public DateTime UpdateQualityLastRan { get; set; }
        public int MaximumAllowedQuality { get => ItemMaximumAllowedQuality; }
        public int InitialDegradationRate { get => ItemInitialDegradationRate; }
        public int PastSellByDegradationRate { get => ItemPastSellByDateDegradationRate; }
    }
}
