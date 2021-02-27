using GildedRose.Model;

namespace GildedRose.Service
{
    internal interface IValidatorStrategy
    {
        void Validate(IItem item);
    }
}
