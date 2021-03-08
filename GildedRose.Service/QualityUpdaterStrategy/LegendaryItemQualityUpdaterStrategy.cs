using GildedRose.Model;
using System;

namespace GildedRose.Service.QualityUpdaterStrategy
{
    internal class LegendaryItemQualityUpdaterStrategy : IQualityUpdaterStrategy
    {
        public void UpdateItemQuality(IItem item)
        {
            //Do nothing. Legendary items do not need to be sold and never have their Quality decreased.
            //Just update its UpdateQualityLastRan 
            item.UpdateQualityLastRan = DateTime.Today;
        }
    }
}
