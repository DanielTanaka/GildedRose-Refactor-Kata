using GildedRose.Model;
using System;

namespace GildedRose.Service.ValidatorStrategy
{
    internal class LegendaryItemValidatorStrategy : IValidatorStrategy
    {
        public void ValidateItem(IItem item)
        {
            if (item.Quality > LegendaryItem.MaximumAllowedQuality)
            {
                throw new Exception($"Item cannot have its Quality greater than {LegendaryItem.MaximumAllowedQuality}");
            }
        }
    }
}
