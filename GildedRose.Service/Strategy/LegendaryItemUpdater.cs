using GildedRose.Model;

namespace GildedRose.Service.Strategy
{
    class LegendaryItemUpdater : IUpdaterStrategy
    {
        public void Update(Item item)
        {
            //Do nothing. Legendary items do not need to be sold and never have their Quality decreased.
            //Check if there's a better way to implement something.
        }
    }
}
