using System;

namespace GildedRose.Model
{
    public class CommonItem : IItem
    {
        public static int MaximumAllowedQuality { get => 50; }

        public string Name { get; set; }
        public int SellIn { get; set; }
        public DateTime SellBy { get; set; }
        public int Quality { get; set; }
    }
}
