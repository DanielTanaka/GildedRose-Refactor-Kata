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
    public class IncreasingQualityItemUpdateQualityTests : TestBase
    {
        private readonly IItemService itemService;

        public IncreasingQualityItemUpdateQualityTests()
        {
            itemService = new ItemService();
        }

        [Fact]
        public void UpdateQuality_ItemWithDefaultValues_ShouldIncreaseQuality()
        {
            var item = new ItemBuilder(new AgedItem())
                .WithDefaultValues()
                .WithQuality(15)
                .Build();
            var newQuality = CalculateNewAgedItemQuality(item);

            itemService.UpdateItemQuality(item);

            item.Quality.Should().Be(newQuality);
        }

        private int CalculateNewAgedItemQuality(IItem item)
        {
            var agedItem = item as AgedItem;
            return agedItem.Quality + (DateTime.Today - agedItem.LastQualityCheckUp).Days * agedItem.QualityIncreasingRate;
        }

        [Fact]
        public void UpdateQuality_ItemWithMaximumQualitySet_ShouldNotIncreaseQuality()
        {
            var item = new AgedItem();
            new ItemBuilder(item)
                .WithDefaultValues()
                .WithQuality(item.MaximumAllowedQuality);

            itemService.UpdateItemQuality(item);

            item.Quality.Should().Be(item.MaximumAllowedQuality);
        }

        [Fact]
        public void UpdateQuality_RunningUpdatesInPeriodsOfLessThan24Hours_ShouldUpdateAccordingly()
        {
            var fakeTodayDate = DateTime.Today.AddDays(-5);
            var item = new AgedItem();
            new ItemBuilder(item)
                .WithDefaultValues()
                .WithQuality(35)
                .WithLastQualityCheckUp(fakeTodayDate)
                .Build();

            for (var i = 0; i < 5; i++)
            {
                fakeTodayDate = fakeTodayDate.AddHours(23);
                Clock.SetTodayDate(fakeTodayDate);
                itemService.UpdateItemQuality(item);
            }

            item.Quality.Should().Be(39);
        }
    }
}
