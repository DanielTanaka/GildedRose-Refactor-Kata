using GildedRose.Model;
using System;

namespace GildedRose.Service.ValidatorStrategy
{
    internal class CommonItemValidatorStrategy : IValidatorStrategy
    {
        public void Validate(IItem item)
        {
            if (item.Quality > CommonItem.MaximumAllowedQuality)
            {
                throw new Exception($"Item cannot have its Quality greater than {CommonItem.MaximumAllowedQuality}");
            }
        }
    }
}
