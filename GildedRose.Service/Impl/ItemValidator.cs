using GildedRose.Model;
using GildedRose.Service.API.Exceptions;

namespace GildedRose.Service.Impl
{
    internal class ItemValidator : IValidatorStrategy
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
        }
    }
}
