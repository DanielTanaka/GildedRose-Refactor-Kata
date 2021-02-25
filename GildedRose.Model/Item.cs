using System;

namespace GildedRose.Model
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public DateTime SellBy { get; set; }

        public int Quality { get; set; }

        public ItemCategory Category { get; set; }

        //Is it ok to leave these Maximum Allowed values here?
        public static int MaximumAllowedQuality { get => 50; }

        public static int LegendaryMaximumAllowedQuality { get => 80; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }
    }
}
