using GildedRose.Model;
using System;

namespace GildedRose.Service.Impl
{
    class Validator : IValidator
    {
        public void Validate(Item item)
        {
            if (item.Quality < 0)
            {
                //TODO: Implement a better exception type
                throw new Exception("Item cannot have a negative Quality");
            }

            if (!ItemCategory.IsLegendary(item.Category) && item.Quality > Item.MaximumAllowedQuality)
            {
                throw new Exception($"Item cannot have its Quality greater than {Item.MaximumAllowedQuality}");
            }

            if (ItemCategory.IsLegendary(item.Category) && item.Quality > Item.LegendaryMaximumAllowedQuality)
            {
                throw new Exception($"Legendary item cannot have its Quality greater than {Item.LegendaryMaximumAllowedQuality}");
            }
        }
    }
}
