using GildedRose.Model;
using GildedRose.Service.ValidatorStrategy;
using System;

namespace GildedRose.Service.Factory
{
    internal class ValidatorFactory
    {
        public static IValidatorStrategy CreateValidatorStrategy(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentException($"{nameof(item)} cannot be null");
            }

            if (item is CommonItem)
            {
                return new CommonItemValidatorStrategy();
            }
            if (item is LegendaryItem)
            {
                return new LegendaryItemValidatorStrategy();
            }

            throw new ArgumentException("Item is of an invalid type");
        }
    }
}
