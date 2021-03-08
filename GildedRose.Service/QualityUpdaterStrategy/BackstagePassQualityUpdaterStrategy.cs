using GildedRose.Model;
using System;

namespace GildedRose.Service.QualityUpdaterStrategy
{
    internal class BackstagePassQualityUpdaterStrategy : IQualityUpdaterStrategy
    {
        public void UpdateItemQuality(IItem item)
        {
            if (item.Quality > 0 || item.Quality < item.MaximumAllowedQuality)
            {
                var differenceInDays = (DateTime.Today - item.UpdateQualityLastRan).Days;
                if (differenceInDays > 0)
                {
                    var daysToBeSold = (item.SellBy - DateTime.Today).Days;
                    if (daysToBeSold <= 0)
                    {
                        item.Quality = 0;
                    }
                    else
                    {
                        var newQuality = item.Quality + differenceInDays;
                        if (daysToBeSold <= 2)
                        {
                            newQuality += differenceInDays * 3;
                            QualityUpdaterHelper.UpdateQualityConsideringMaximumThreshold(item, newQuality);
                        }
                        else if (daysToBeSold <= 5)
                        {
                            newQuality += differenceInDays * 2;
                            QualityUpdaterHelper.UpdateQualityConsideringMaximumThreshold(item, newQuality);
                        }
                        else
                        {
                            QualityUpdaterHelper.UpdateQualityConsideringMaximumThreshold(item, newQuality);
                        }
                    }
                }
            }
            item.UpdateQualityLastRan = DateTime.Today;
        }
    }
}
