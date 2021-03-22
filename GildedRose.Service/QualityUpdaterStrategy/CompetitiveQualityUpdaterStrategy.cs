using GildedRose.Model;
using System;

namespace GildedRose.Service.QualityUpdaterStrategy
{
    internal class CompetitiveQualityUpdaterStrategy : IQualityUpdaterStrategy
    {
        public void UpdateItemQuality(IItem item)
        {
            //TODO: Try to improve this code
            if (!(item is ICompetitiveQualityItem competitiveItem))
            {
                throw new ArgumentException($"Item is not of type {nameof(ICompetitiveQualityItem)}");
            }

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
                        var newQuality = competitiveItem.Quality + differenceInDays * competitiveItem.QualityDegradationRate;
                        if (daysToBeSold <= 2)
                        {
                            newQuality += newQuality * 3;
                        }
                        else if (daysToBeSold <= 5)
                        {
                            newQuality += newQuality * 2;
                        }
                        QualityUpdaterHelper.UpdateQualityConsideringMaximumThreshold(competitiveItem, newQuality);
                    }
                }
            }
            competitiveItem.LastQualityCheckUp = DateTime.Today;
        }
    }
}
