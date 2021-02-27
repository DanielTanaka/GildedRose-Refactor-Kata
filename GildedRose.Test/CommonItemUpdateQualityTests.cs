using FluentAssertions;
using GildedRose.Model;
using GildedRose.Test.Builders;
using System;
using Xunit;

namespace GildedRose.Test
{
    public class CommonItemUpdateQualityTests
    {
        [Fact]
        public void UpdateQuality_ItemWithinSellByDate_ShouldUpdateCorrectly()
        {
            var item = new ItemBuilder(new CommonItem())
                .WithQuality(50)
                .WithSellByDate(DateTime.Today.AddDays(15))
                .Build();

            item.UpdateQuality();

            item.Quality.Should().Be(49);
        }

        [Fact]
        public void UpdateQuality_ItemWithPastSellByDate_ShouldDegradeQualityTwiceAsFast()
        {
            var item = new ItemBuilder(new CommonItem())
                .WithQuality(50)
                .WithSellByDate(DateTime.Today.AddDays(-15))
                .Build();

            item.UpdateQuality();

            item.Quality.Should().Be(48);
        }
    }
}
