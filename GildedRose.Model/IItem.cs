using System;

namespace GildedRose.Model
{
    public interface IItem
    {
        string Name { get; set; }

        int Quality { get; set; }

        DateTime LastQualityCheckUp { get; set; }

        int MaximumAllowedQuality { get; }
    }
}
