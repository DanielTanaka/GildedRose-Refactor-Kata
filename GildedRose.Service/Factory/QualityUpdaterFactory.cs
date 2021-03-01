using GildedRose.Model;
using GildedRose.Service.QualityUpdaterStrategy;
using System;

namespace GildedRose.Service.Factory
{
    internal class QualityUpdaterFactory
    {
        //TODO: Finish implementing for other item types. Only implementing Common and Legendary items for now
        public static IQualityUpdaterStrategy CreateQualityUpdaterStrategy(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException($"{nameof(item)} cannot be null");
            }

            if (item is CommonItem)
            {
                return new CommonItemQualityUpdaterStrategy();
            }
            if (item is LegendaryItem)
            {
                return new LegendaryItemQualityUpdaterStrategy();
            }

            throw new ArgumentException("Item is of an invalid type");
        }
    }
}
