using FluentAssertions;
using GildedRose.Commons;
using GildedRose.Model;
using GildedRose.Service.API;
using GildedRose.Service.Impl;
using GildedRose.Test.Builders;
using System;
using Xunit;

namespace GildedRose.Test
{
    public class DecreasingQualityItemUpdateQualityTests : TestBase
    {
        private readonly IItemService itemService;

        public DecreasingQualityItemUpdateQualityTests()
        {
            itemService = new ItemService();
        }

        //TODO: Think of a better structure for ItemBuilder, since now we have new IItem subtypes
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void UpdateQuality_ItemWithinSellByDate_ShouldUpdateQualityCorrectly(int lastCheckUpThisManyDaysAgo)
        {
            var item = new CommonItem();
            new ItemBuilder(item)
                .WithDefaultValues()
                .WithLastQualityCheckUp(DateTime.Today.AddDays(-lastCheckUpThisManyDaysAgo))
                .Build();
            item.SellBy = DateTime.Today.AddDays(15);
            var updatedQuality = item.Quality - item.QualityDegradationRate * lastCheckUpThisManyDaysAgo;

            itemService.UpdateItemQuality(item);

            item.Quality.Should().Be(updatedQuality);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void UpdateQuality_ItemWithPastSellByDate_ShouldDegradeQualityTwiceAsFast(int lastCheckUpThisManyDaysAgo)
        {
            var item = new CommonItem();
            new ItemBuilder(item)
                .WithDefaultValues()
                .WithLastQualityCheckUp(DateTime.Today.AddDays(-lastCheckUpThisManyDaysAgo))
                .Build();
            item.SellBy = DateTime.Today.AddDays(-15);

            var qualityDegradedTwiceAsFast = item.Quality - item.QualityDegradationRate * lastCheckUpThisManyDaysAgo * 2;

            itemService.UpdateItemQuality(item);

            item.Quality.Should().Be(qualityDegradedTwiceAsFast);
        }

        [Theory]
        [InlineData(30)]
        [InlineData(40)]
        public void UpdateQuality_ItemWithPastSellByDate_ShouldDegradeQualityTwiceAsFastLimitedToMinimumOfZero(int lastCheckUpThisManyDaysAgo)
        {
            var item = new CommonItem();
            new ItemBuilder(item)
                .WithDefaultValues()
                .WithLastQualityCheckUp(DateTime.Today.AddDays(-lastCheckUpThisManyDaysAgo))
                .Build();
            item.SellBy = DateTime.Today.AddDays(-15);

            itemService.UpdateItemQuality(item);

            item.Quality.Should().Be(0);
        }

        [Fact]
        public void UpdateQuality_ItemLastQualityCheckUpDifferenceGreaterThanItsQuality_ShouldUpdateQualityToZero()
        {
            var item = new CommonItem();
            new ItemBuilder(item)
                .WithDefaultValues()
                .WithLastQualityCheckUp(DateTime.Today.AddDays(-52))
                .Build();
            item.SellBy = DateTime.Today.AddDays(15);

            itemService.UpdateItemQuality(item);

            item.Quality.Should().Be(0);
        }

        [Fact]
        public void UpdateQuality_RunningUpdatesInPeriodsOfLessThan24Hours_ShouldUpdateAccordingly()
        {
            var fakeTodayDate = DateTime.Today.AddDays(-5);
            var item = new CommonItem();
            new ItemBuilder(item)
                .WithDefaultValues()
                .WithLastQualityCheckUp(fakeTodayDate)
                .Build();
            item.SellBy = DateTime.Today.AddDays(10);

            var wholeDays = 0;
            var originalQuality = item.Quality;
            var theoreticalLastItemCheckUp = item.LastQualityCheckUp;
            Clock.Today = () => fakeTodayDate;
            for (var i = 0; i < 5; i++)
            {
                itemService.UpdateItemQuality(item);
                fakeTodayDate = fakeTodayDate.AddHours(23);

                if ((fakeTodayDate - theoreticalLastItemCheckUp).Days > 0)
                {
                    wholeDays++;
                    theoreticalLastItemCheckUp = Clock.Today();
                }

                Clock.Today = () => fakeTodayDate;
            }

            var updatedQuality = originalQuality - item.QualityDegradationRate * wholeDays;
            item.Quality.Should().Be(updatedQuality);
        }
    }
}
