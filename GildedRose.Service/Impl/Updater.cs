using GildedRose.Model;
using GildedRose.Service.Factory;

namespace GildedRose.Service.Impl
{
    public class Updater
    {
        public void Update(IItem item)
        {
            new Validator().Validate(item);
            var qualityUpdaterStrategy = QualityUpdaterFactory.CreateQualityUpdaterStrategy(item);

            qualityUpdaterStrategy.Update(item);
        }
    }
}
