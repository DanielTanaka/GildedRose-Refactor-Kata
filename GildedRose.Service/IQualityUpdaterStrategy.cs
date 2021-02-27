using GildedRose.Model;

namespace GildedRose.Service
{
    internal interface IQualityUpdaterStrategy
    {
        void Update(IItem item); 
    }
}
