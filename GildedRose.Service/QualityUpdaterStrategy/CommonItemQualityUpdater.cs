using GildedRose.Model;
using System;

namespace GildedRose.Service.QualityUpdaterStrategy
{
    internal class CommonItemQualityUpdater : IQualityUpdaterStrategy
    {
        private const int decreaseTwiceAsFast = 2;

        public void Update(IItem item)
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
