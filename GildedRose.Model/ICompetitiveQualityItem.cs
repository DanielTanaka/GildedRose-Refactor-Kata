using System;

namespace GildedRose.Model
{
    public interface ICompetitiveQualityItem : IItem
    {
        DateTime SellBy { get; set; }

        int QualityDegradationRate { get; }
    }
}
