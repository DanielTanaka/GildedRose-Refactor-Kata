using GildedRose.Model;
using System;

namespace GildedRose.Service.QualityUpdaterStrategy
{
    internal class CompetitiveQualityUpdaterStrategy : IQualityUpdaterStrategy
    {
        public void UpdateItemQuality(IItem item)
        {
            var competitiveItem = item as ICompetitiveQualityItem;
            if (competitiveItem != null)
            {
                if (competitiveItem.Quality > 0 || competitiveItem.Quality < competitiveItem.MaximumAllowedQuality)
                {
                    var differenceInDays = (DateTime.Today - competitiveItem.LastQualityCheckUp).Days;
                    if (differenceInDays > 0)
                    {
                        var daysToBeSold = (competitiveItem.SellBy - DateTime.Today).Days;
                        if (daysToBeSold <= 0)
                        {
                            competitiveItem.Quality = 0;
                        }
                        else
                        {
                            //TODO: Use new Rate property
                            var newQuality = competitiveItem.Quality + differenceInDays;
                            if (daysToBeSold <= 2)
                            {
                                newQuality += differenceInDays * 3;
                                QualityUpdaterHelper.UpdateQualityConsideringMaximumThreshold(competitiveItem, newQuality);
                            }
                            else if (daysToBeSold <= 5)
                            {
                                newQuality += differenceInDays * 2;
                                QualityUpdaterHelper.UpdateQualityConsideringMaximumThreshold(competitiveItem, newQuality);
                            }
                            else
                            {
                                QualityUpdaterHelper.UpdateQualityConsideringMaximumThreshold(competitiveItem, newQuality);
                            }
                        }
                    }
                } 
            }
            competitiveItem.LastQualityCheckUp = DateTime.Today;
        }
    }
}
