using System;

namespace GildedRose.Model
{
    public interface IItem
    {
        static int MaximumAllowedQuantity { get; }

        string Name { get; set; }

        int SellIn { get; set; }

        DateTime SellBy { get; set; }

        int Quality { get; set; }
    }
}
