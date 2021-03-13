using GildedRose.Model;
using System;

namespace GildedRose.Service.QualityUpdaterStrategy
{
    internal class DecreasingQualityUpdaterStrategy : IQualityUpdaterStrategy
    {
        public void UpdateItemQuality(IItem item)
        {
            var commonItem = item as IDecreasingQualityItem;
            if (commonItem != null)
            {
                if (commonItem.Quality > 0)
                {
                    var differenceInDays = (DateTime.Today - commonItem.LastQualityCheckUp).Days;
                    if (differenceInDays > 0)
                    {
                        int newQuality;
                        if (commonItem.SellBy < DateTime.Today)
                        {
                            newQuality = commonItem.Quality - 2 * commonItem.QualityDegradationRate * differenceInDays;
                        }
                        else
                        {
                            newQuality = commonItem.Quality - commonItem.QualityDegradationRate * differenceInDays;
                        }
                        QualityUpdaterHelper.UpdateQualityConsideringMinimumThreshold(commonItem, newQuality);
                    }
                }
                item.LastQualityCheckUp = DateTime.Today;
            }
        }
    }
}
