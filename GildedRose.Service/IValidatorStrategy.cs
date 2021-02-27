using GildedRose.Model;

namespace GildedRose.Service
{
    internal interface IValidatorStrategy
    {
        void ValidateItem(IItem item);
    }
}
