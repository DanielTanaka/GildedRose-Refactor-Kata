using GildedRose.Model;
using System;

namespace GildedRose.Service.QualityUpdaterStrategy
{
    internal class DecreasingQualityUpdaterStrategy : IQualityUpdaterStrategy
    {
        public void UpdateItemQuality(IItem item)
        {
            if (!(item is IDecreasingQualityItem decreasingQualityItem))
            {
                throw new ArgumentException($"Using an incorrect strategy: Item is not of type {nameof(IDecreasingQualityItem)}");
            }

            if (decreasingQualityItem.Quality > 0)
            {
                var differenceInDays = (DateTime.Today - decreasingQualityItem.LastQualityCheckUp).Days;
                if (differenceInDays > 0)
                {
                    int newQuality;
                    if (decreasingQualityItem.SellBy < DateTime.Today)
                    {
                        newQuality = decreasingQualityItem.Quality - 2 * decreasingQualityItem.QualityDegradationRate * differenceInDays;
                    }
                    else
                    {
                        newQuality = decreasingQualityItem.Quality - decreasingQualityItem.QualityDegradationRate * differenceInDays;
                    }
                    QualityUpdaterHelper.UpdateQualityConsideringMinimumThreshold(decreasingQualityItem, newQuality);
                }
            }
            item.LastQualityCheckUp = DateTime.Today;
        }
    }
}
