using GildedRose.Model;
using System;

namespace GildedRose.Service.QualityUpdaterStrategy
{
    internal class IncreasingQualityUpdaterStrategy : IQualityUpdaterStrategy
    {
        public void UpdateItemQuality(IItem item)
        {
            if (!(item is IIncreasingQualityItem increasingQualityItem))
            {
                throw new ArgumentException($"Item is not of type {nameof(IIncreasingQualityItem)}");
            }
            
            if (increasingQualityItem.Quality < increasingQualityItem.MaximumAllowedQuality)
            {
                var differenceInDays = (DateTime.Today - increasingQualityItem.LastQualityCheckUp).Days;
                if (differenceInDays > 0)
                {
                    var newQuality = increasingQualityItem.Quality + increasingQualityItem.QualityIncreasingRate * differenceInDays;
                    QualityUpdaterHelper.UpdateQualityConsideringMaximumThreshold(increasingQualityItem, newQuality);
                }
            }
            item.LastQualityCheckUp = DateTime.Today;
        }
    }
}
