using System;

namespace GildedRose.Model
{
    public interface IItem
    {
        string Name { get; set; }

        int SellIn { get; set; }

        DateTime SellBy { get; set; }

        int Quality { get; set; }

        static int MaximumAllowedQuantity { get; }

        void UpdateQuality();
    }
}
