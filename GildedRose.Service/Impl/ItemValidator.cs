using GildedRose.Model;
using GildedRose.Service.Factory;
using System;

namespace GildedRose.Service.Impl
{
    internal class ItemValidator : IValidatorStrategy
    {
        public void ValidateItem(IItem item)
        {
            if (item.Quality < 0)
            {
                //TODO: Implement a better exception type
                throw new Exception("Item cannot have a negative Quality");
            }

            var validatorStrategy = ValidatorFactory.CreateValidatorStrategy(item);
            validatorStrategy.ValidateItem(item);
        }
    }
}
