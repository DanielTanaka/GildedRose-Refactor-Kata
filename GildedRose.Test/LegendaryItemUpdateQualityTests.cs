using FluentAssertions;
using GildedRose.Model;
using GildedRose.Service.API;
using GildedRose.Service.Impl;
using GildedRose.Test.Builders;
using System;
using Xunit;

namespace GildedRose.Test
{
    public class LegendaryItemUpdateQualityTests
    {
        private readonly IItemService itemService;

        //TODO: Use this with Dependency Injection later
        public LegendaryItemUpdateQualityTests()
        {
            itemService = new ItemService();
        }

        [Fact]
        //Legendary Items don't need to be sold nor decreases in Quality
        public void UpdateQuality_ItemWithinSellByDate_ShouldDoNothing()
        {
            var item = new ItemBuilder(new LegendaryItem())
                .WithQuality(50)
                .WithSellByDate(DateTime.Today.AddDays(15))
                .Build();

            itemService.UpdateItemQuality(item);

            item.Quality.Should().Be(50);
        }
    }
}
