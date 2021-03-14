using FluentAssertions;
using GildedRose.Model;
using GildedRose.Service.API;
using GildedRose.Service.Impl;
using GildedRose.Test.Builders;
using System;
using Xunit;

namespace GildedRose.Test
{
    public class SteadyQualityItemUpdateQualityTests
    {
        private readonly IItemService itemService;

        public SteadyQualityItemUpdateQualityTests()
        {
            itemService = new ItemService();
        }

        //Legendary Items don't need to be sold nor decreases in Quality
        [Fact]
        public void UpdateQuality_ItemWithinSellByDate_ShouldDoNothing()
        {
            var item = new ItemBuilder(new LegendaryItem())
                .WithDefaultValues()
                .Build();
            var previousItemQuality = item.Quality;

            itemService.UpdateItemQuality(item);

            item.Quality.Should().Be(previousItemQuality);
            item.LastQualityCheckUp.Should().Be(DateTime.Today);
        }
    }
}
