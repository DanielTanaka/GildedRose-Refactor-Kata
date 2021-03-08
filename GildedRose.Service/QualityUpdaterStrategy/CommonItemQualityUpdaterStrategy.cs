using GildedRose.Model;
using System;

namespace GildedRose.Service.QualityUpdaterStrategy
{
    internal class CommonItemQualityUpdaterStrategy : IQualityUpdaterStrategy
    {
        public void UpdateItemQuality(IItem item)
        {
            var commonItem = item as CommonItem;
            if (commonItem != null)
            {
                if (commonItem.Quality > 0)
                {
                    var differenceInDays = (DateTime.Today - commonItem.UpdateQualityLastRan).Days;
                    if (differenceInDays > 0)
                    {
                        if (commonItem.SellBy < DateTime.Today)
                        {
                            var newQuality = commonItem.Quality - commonItem.PastSellByDateDegradationRate * differenceInDays;
                            QualityUpdaterHelper.UpdateQualityConsideringMinimumThreshold(commonItem, newQuality);
                        }
                        else
                        {
                            var newQuality = commonItem.Quality - commonItem.DegradationRate * differenceInDays;
                            QualityUpdaterHelper.UpdateQualityConsideringMinimumThreshold(commonItem, newQuality);
                        }
                    }
                }
                item.UpdateQualityLastRan = DateTime.Today;
            }
        }
    }
}
