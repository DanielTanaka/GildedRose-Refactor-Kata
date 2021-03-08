using GildedRose.Model;
using GildedRose.Service.QualityUpdaterStrategy;
using System;

namespace GildedRose.Service.Factory
{
    internal class QualityUpdaterFactory
    {
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
            if (item is ConjuredItem)
            {
                return new ConjuredItemQualityUpdaterStrategy();
            }
            if (item is AgedItem)
            {
                return new AgedItemQualityUpdaterStrategy();
            }
            if (item is BackstagePassItem)
            {
                return new BackstagePassQualityUpdaterStrategy();
            }

            throw new ArgumentException("Item is of an invalid type");
        }
    }
}
