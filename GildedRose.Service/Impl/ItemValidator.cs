using GildedRose.Model;
using GildedRose.Service.API.Exceptions;
using System;

namespace GildedRose.Service.Impl
{
    internal class ItemValidator
    {
        public void ValidateItem(IItem item)
        {
            if (item.Quality < 0)
            {
                throw new QualityOutOfRangeException("Item cannot have a negative Quality");
            }
            if (item.Quality > item.MaximumAllowedQuality)
            {
                throw new QualityOutOfRangeException(item.MaximumAllowedQuality);
            }
            //TODO: Implement a better exception
            if (item.LastQualityCheckUp > DateTime.Today)
            {
                throw new Exception($"Item cannot have its {nameof(item.LastQualityCheckUp)} in the future");
            }
        }
    }
}
