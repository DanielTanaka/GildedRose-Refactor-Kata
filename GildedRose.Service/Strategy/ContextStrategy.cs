using GildedRose.Model;

namespace GildedRose.Service.Strategy
{
    class ContextStrategy : IUpdaterStrategy
    {
        private readonly IValidator validator;
        private IUpdaterStrategy updater;

        public ContextStrategy(IValidator validator)
        {
            this.validator = validator;
        }

        public void SetUpdaterStrategy(IUpdaterStrategy updater)
        {
            this.updater = updater;
        }

        public void Update(Item item)
        {
            validator.Validate(item);
            updater.Update(item);
        }
    }
}
