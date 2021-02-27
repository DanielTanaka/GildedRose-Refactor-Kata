using GildedRose.Model;
using GildedRose.Service.API;
using GildedRose.Service.Factory;

namespace GildedRose.Service.Impl
{
    public class ItemService : IItemService
    {
        public void UpdateItemQuality(IItem item)
        {
            new ItemValidator().ValidateItem(item);
            var qualityUpdaterStrategy = QualityUpdaterFactory.CreateQualityUpdaterStrategy(item);

            qualityUpdaterStrategy.UpdateItemQuality(item);
        }
    }
}
