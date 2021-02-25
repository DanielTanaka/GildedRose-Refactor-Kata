using GildedRose.Model;
using System;

namespace GildedRose.Service.Strategy
{
    class CommonItemUpdater : IUpdaterStrategy
    {
        private const int decreaseTwiceAsFast = 2;

        public void Update(Item item)
        {
            if (item.Quality > 0)
            {
                if (item.SellBy < DateTime.Today)
                {
                    item.Quality -= decreaseTwiceAsFast;
                }
                else
                {
                    item.Quality--;
                }
            }
        }
    }
}
