using GildedRose.Model;
using System;

namespace GildedRose.Service.QualityUpdaterStrategy
{
    internal class SteadyQualityUpdaterStrategy : IQualityUpdaterStrategy
    {
        public void UpdateItemQuality(IItem item)
        {
            //Do nothing. Legendary items do not need to be sold and never have their Quality decreased.
            //Just update its LastQualityCheckUp 
            if (!(item is ISteadyQualityItem))
            {
                throw new ArgumentException($"Item is not of type {nameof(ISteadyQualityItem)}");
            }

            item.LastQualityCheckUp = DateTime.Today;
        }
    }
}
