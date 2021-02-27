using GildedRose.Model;

namespace GildedRose.Service
{
    internal interface IQualityUpdaterStrategy
    {
        void UpdateItemQuality(IItem item); 
    }
}
