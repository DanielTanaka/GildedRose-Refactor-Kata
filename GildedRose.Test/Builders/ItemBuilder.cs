using GildedRose.Model;
using System;

namespace GildedRose.Test.Builders
{
    class ItemBuilder
    {
        private readonly IItem item;

        public ItemBuilder(IItem item)
        {
            this.item = item;
        }

        public ItemBuilder WithDefaultValues()
        {
            item.Name = "test";
            item.Quality = 35;
            item.LastQualityCheckUp = DateTime.Today.AddDays(-1);

            return this;
        }

        public ItemBuilder WithName(string name)
        {
            item.Name = name;

            return this;
        }

        public ItemBuilder WithQuality(int quality)
        {
            item.Quality = quality;

            return this;
        }

        public ItemBuilder WithLastQualityCheckUp(DateTime lastRan)
        {
            item.LastQualityCheckUp = lastRan;

            return this;
        }

        public IItem Build()
        {
            return item;
        }
    }
}
