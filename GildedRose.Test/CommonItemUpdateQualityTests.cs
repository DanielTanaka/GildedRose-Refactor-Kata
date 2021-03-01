using FluentAssertions;
using GildedRose.Model;
using GildedRose.Service.API;
using GildedRose.Service.Impl;
using GildedRose.Test.Builders;
using System;
using Xunit;

namespace GildedRose.Test
{
    public class CommonItemUpdateQualityTests
    {
        private readonly IItemService itemService;

        public CommonItemUpdateQualityTests()
        {
            itemService = new ItemService();
        }

        [Fact]
        public void UpdateQuality_ItemWithinSellByDate_ShouldUpdateCorrectly()
        {
            var item = new ItemBuilder(new CommonItem())
                .WithQuality(50)
                .WithSellByDate(DateTime.Today.AddDays(15))
                .Build();

            itemService.UpdateItemQuality(item);

            item.Quality.Should().Be(49);
        }

        [Fact]
        public void UpdateQuality_ItemWithPastSellByDate_ShouldDegradeQualityTwiceAsFast()
        {
            var item = new ItemBuilder(new CommonItem())
                .WithQuality(50)
                .WithSellByDate(DateTime.Today.AddDays(-15))
                .Build();

            itemService.UpdateItemQuality(item);

            item.Quality.Should().Be(48);
        }
    }
}
