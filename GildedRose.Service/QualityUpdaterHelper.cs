using GildedRose.Model;

namespace GildedRose.Service
{
    internal class QualityUpdaterHelper
    {
        public static void UpdateQualityConsideringMaximumThreshold(IItem item, int newQuality)
        {
            if (newQuality > item.MaximumAllowedQuality)
            {
                item.Quality = item.MaximumAllowedQuality;
            }
            else
            {
                item.Quality = newQuality;
            }
        }

        public static void UpdateQualityConsideringMinimumThreshold(IItem item, int newQuality)
        {
            if (newQuality < 0)
            {
                item.Quality = 0;
            }
            else
            {
                item.Quality = newQuality;
            }
        }
    }
}
