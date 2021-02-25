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

        public IItem Build()
        {
            return item;
        }
    }
}
