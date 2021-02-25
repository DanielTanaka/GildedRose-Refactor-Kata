using GildedRose.Model;
using GildedRose.Service.Strategy;

namespace GildedRose.Service.Impl
{
    public class Updater : IUpdaterStrategy
    {
        //TODO: Change the 'Updater' classes to 'QualityUpdater'.
        //We need to specify what's going to be updated by these methods

        private readonly LegendaryItemUpdater legendaryItemUpdater;
        private readonly CommonItemUpdater commonItemUpdater;
        private readonly ContextStrategy contextStrategy;

        public Updater(IValidator validator)
        {
            commonItemUpdater = new CommonItemUpdater();
            legendaryItemUpdater = new LegendaryItemUpdater();
            contextStrategy = new ContextStrategy(validator);
        }

        public void Update(Item item)
        {
            //TODO: Finish implementing all other strategies
            if (ItemCategory.IsCommon(item.Category))
            {
                contextStrategy.SetUpdaterStrategy(commonItemUpdater);
                contextStrategy.Update(item);
            } 
            else if (ItemCategory.IsLegendary(item.Category))
            {
                contextStrategy.SetUpdaterStrategy(legendaryItemUpdater);
                contextStrategy.Update(item);
            }
            else if (ItemCategory.IsAged(item.Category))
            {
                contextStrategy.SetUpdaterStrategy(commonItemUpdater);
                contextStrategy.Update(item);
            }
            else
            {
                throw new System.Exception($"{item.Name} is of an unknown Category");
            }
        }
    }
}
