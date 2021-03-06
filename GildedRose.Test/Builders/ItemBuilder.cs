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
            item.SellBy = DateTime.Today.AddDays(15);
            item.Quality = item.MaximumAllowedQuality;
            item.UpdateQualityLastRan = DateTime.Today.AddDays(-1);

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

        public ItemBuilder WithSellByDate(DateTime date)
        {
            item.SellBy = date;

            return this;
        }

        public ItemBuilder WithUpdateQualityLastRan(DateTime lastRan)
        {
            item.UpdateQualityLastRan = lastRan;

            return this;
        }

        public IItem Build()
        {
            return item;
        }
    }
}
