using GildedRose.Model;
using System;

namespace GildedRose.Service.ValidatorStrategy
{
    internal class LegendaryItemValidatorStrategy : IValidatorStrategy
    {
        public void Validate(IItem item)
        {
            if (item.Quality > LegendaryItem.MaximumAllowedQuality)
            {
                throw new Exception($"Item cannot have its Quality greater than {LegendaryItem.MaximumAllowedQuality}");
            }
        }
    }
}
