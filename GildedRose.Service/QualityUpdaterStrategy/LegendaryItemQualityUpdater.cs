using GildedRose.Model;

namespace GildedRose.Service.QualityUpdaterStrategy
{
    internal class LegendaryItemQualityUpdater : IQualityUpdaterStrategy
    {
        public void Update(IItem item)
        {
            //Do nothing. Legendary items do not need to be sold and never have their Quality decreased.
            //Check if there's a better way to implement something.
        }
    }
}
