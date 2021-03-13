using GildedRose.Model;
using GildedRose.Service.QualityUpdaterStrategy;
using System;

namespace GildedRose.Service.Factory
{
    internal class QualityUpdaterFactory
    {
        public static IQualityUpdaterStrategy CreateQualityUpdaterStrategy(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException($"{nameof(item)} cannot be null");
            }

            if (item is IDecreasingQualityItem)
            {
                return new DecreasingQualityUpdaterStrategy();
            }
            if (item is ISteadyQualityItem)
            {
                return new SteadyQualityUpdaterStrategy();
            }
            if (item is IIncreasingQualityItem)
            {
                return new IncreasingQualityUpdaterStrategy();
            }
            if (item is ICompetitiveQualityItem)
            {
                return new CompetitiveQualityUpdaterStrategy();
            }

            throw new ArgumentException("Item is of an invalid type");
        }
    }
}
