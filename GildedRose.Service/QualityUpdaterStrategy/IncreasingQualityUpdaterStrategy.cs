using GildedRose.Model;
using System;

namespace GildedRose.Service.QualityUpdaterStrategy
{
    internal class IncreasingQualityUpdaterStrategy : IIncreasingQualityUpdaterStrategy
    {
        public void UpdateItemQuality(IItem item)
        {
            var agedItem = item as IIncreasingQualityItem;
            if (agedItem != null)
            {
                if (agedItem.Quality < agedItem.MaximumAllowedQuality)
                {
                    var differenceInDays = (DateTime.Today - agedItem.LastQualityCheckUp).Days;
                    if (differenceInDays > 0)
                    {
                        var newQuality = agedItem.Quality + agedItem.QualityIncreasingRate * differenceInDays;
                        QualityUpdaterHelper.UpdateQualityConsideringMaximumThreshold(agedItem, newQuality);
                    }
                }
                item.LastQualityCheckUp = DateTime.Today;
            }
        }
    }
}
