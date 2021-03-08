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

        //TODO: Use new Degradation Rate property in each test

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void UpdateQuality_ItemWithinSellByDate_ShouldUpdateQualityCorrectly(int lastRanThisManyDaysAgo)
        {
            var item = new ItemBuilder(new CommonItem())
                .WithDefaultValues()
                .WithUpdateQualityLastRan(DateTime.Today.AddDays(-lastRanThisManyDaysAgo))
                .Build();
            var updatedQuality = item.Quality - lastRanThisManyDaysAgo;

            itemService.UpdateItemQuality(item);

            item.Quality.Should().Be(updatedQuality);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void UpdateQuality_ItemWithPastSellByDate_ShouldDegradeQualityTwiceAsFast(int lastRanThisManyDaysAgo)
        {
            var item = new ItemBuilder(new CommonItem())
                .WithDefaultValues()
                .WithSellByDate(DateTime.Today.AddDays(-15))
                .WithUpdateQualityLastRan(DateTime.Today.AddDays(-lastRanThisManyDaysAgo))
                .Build();

            var qualityDegradedTwiceAsFast = item.Quality - lastRanThisManyDaysAgo * 2;

            itemService.UpdateItemQuality(item);

            item.Quality.Should().Be(qualityDegradedTwiceAsFast);
        }

        [Theory]
        [InlineData(30)]
        [InlineData(40)]
        public void UpdateQuality_ItemWithPastSellByDate_ShouldDegradeQualityTwiceAsFastLimitedToMinimumOfZero(int lastRanThisManyDaysAgo)
        {
            var item = new ItemBuilder(new CommonItem())
                .WithDefaultValues()
                .WithSellByDate(DateTime.Today.AddDays(-15))
                .WithUpdateQualityLastRan(DateTime.Today.AddDays(-lastRanThisManyDaysAgo))
                .Build();

            itemService.UpdateItemQuality(item);

            item.Quality.Should().Be(0);
        }

        [Fact]
        public void UpdateQuality_ItemUpdateQualityLastRanDifferenceGreaterThanItsQuality_ShouldUpdateQualityToZero()
        {
            var item = new ItemBuilder(new CommonItem())
                .WithDefaultValues()
                .WithUpdateQualityLastRan(DateTime.Today.AddDays(-52))
                .Build();

            itemService.UpdateItemQuality(item);

            item.Quality.Should().Be(0);
        }
    }
}
