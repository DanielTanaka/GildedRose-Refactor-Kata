using GildedRose.Model;
using System;

namespace GildedRose.Service.QualityUpdaterStrategy
{
    internal class CommonItemQualityUpdaterStrategy : IQualityUpdaterStrategy
    {
        private const int decreaseTwiceAsFast = 2;

        public void UpdateItemQuality(IItem item)
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
