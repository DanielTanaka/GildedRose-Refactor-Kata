using System;

namespace GildedRose.Model
{
    public class LegendaryItem : IItem
    {
        public static int MaximumAllowedQuality { get => 80; }

        public string Name { get; set; }
        public int SellIn { get; set; }
        public DateTime SellBy { get; set; }
        public int Quality { get; set; }
    }
}
