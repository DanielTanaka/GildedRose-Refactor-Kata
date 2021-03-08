using GildedRose.Model;
using System;

namespace GildedRose.Service.QualityUpdaterStrategy
{
    internal class AgedItemQualityUpdaterStrategy : IQualityUpdaterStrategy
    {
        public void UpdateItemQuality(IItem item)
        {
            var agedItem = item as AgedItem;
            if (agedItem != null)
            {
                if (agedItem.Quality < agedItem.MaximumAllowedQuality)
                {
                    var differenceInDays = (DateTime.Today - agedItem.UpdateQualityLastRan).Days;
                    if (differenceInDays > 0)
                    {
                        var newQuality = agedItem.Quality + agedItem.QualityIncreasingRate * differenceInDays;
                        QualityUpdaterHelper.UpdateQualityConsideringMaximumThreshold(agedItem, newQuality);
                    }
                }
                item.UpdateQualityLastRan = DateTime.Today;
            }
        }
    }
}
