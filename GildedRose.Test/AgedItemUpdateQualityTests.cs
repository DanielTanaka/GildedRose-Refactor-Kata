using FluentAssertions;
using GildedRose.Model;
using GildedRose.Service.API;
using GildedRose.Service.Impl;
using GildedRose.Test.Builders;
using System;
using Xunit;

namespace GildedRose.Test
{
    public class AgedItemUpdateQualityTests
    {
        private readonly IItemService itemService;

        public AgedItemUpdateQualityTests()
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

        private int CalculateNewAgedItemQuality(IItem item)
        {
            var agedItem = item as AgedItem;
            return agedItem.Quality + (DateTime.Today - agedItem.LastQualityCheckUp).Days * agedItem.QualityIncreasingRate;
        }
    }
}
