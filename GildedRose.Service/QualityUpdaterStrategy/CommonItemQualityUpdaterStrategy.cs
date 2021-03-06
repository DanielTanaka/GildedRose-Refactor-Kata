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
                var differenceInDays = (DateTime.Today - item.UpdateQualityLastRan).Days;
                if (differenceInDays > 0)
                {
                    if (item.SellBy < DateTime.Today)
                    {
                        var newQuality = item.Quality - differenceInDays * decreaseTwiceAsFast;
                        ValidateAndUpdateNewQuality(item, newQuality);
                    }
                    else
                    {
                        var newQuality = item.Quality - differenceInDays;
                        ValidateAndUpdateNewQuality(item, newQuality);
                    }
                }
            }
        }

        private void ValidateAndUpdateNewQuality(IItem item, int newQuality)
        {
            if (newQuality < 0)
            {
                item.Quality = 0;
            }
            else
            {
                item.Quality = newQuality;
            }
        }
    }
}
