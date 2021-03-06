﻿using System;

namespace GildedRose.Model
{
    public interface IItem
    {
        string Name { get; set; }

        DateTime SellBy { get; set; }

        int Quality { get; set; }

        DateTime UpdateQualityLastRan { get; set; }

        int MaximumAllowedQuality { get; }
    }
}
