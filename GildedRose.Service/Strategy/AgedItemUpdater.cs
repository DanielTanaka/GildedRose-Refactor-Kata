using GildedRose.Model;

namespace GildedRose.Service.Strategy
{
    class AgedItemUpdater : IUpdaterStrategy
    {
        public void Update(Item item)
        {
            if (item.Quality < Item.MaximumAllowedQuality)
            {
                item.Quality++;
            }
        }
    }
}
