using System;

namespace GildedRose.Model
{
    public interface IDecreasingQualityItem : IItem
    {
        DateTime SellBy { get; set; }

        int QualityDegradationRate { get; }
    }
}
