using FluentAssertions;
using GildedRose.Model;
using GildedRose.Test.Builders;
using System;
using Xunit;

namespace GildedRose.Test
{
    public class LegendaryItemUpdateQualityTests
    {
        [Fact]
        //Legendary Items don't need to be sold nor decreases in Quality
        public void UpdateQuality_ItemWithinSellByDate_ShouldNotDoAnything()
        {
            var item = new ItemBuilder(new LegendaryItem())
                .WithQuality(50)
                .WithSellByDate(DateTime.Today.AddDays(15))
                .Build();

            item.UpdateQuality();

            item.Quality.Should().Be(50);
        }

        [Theory]
        [InlineData(95)]
        [InlineData(-1)]
        public void UpdateQuality_ItemWithInvalidQuality_ShouldThrownAnException(int quality)
        {
            var item = new ItemBuilder(new LegendaryItem())
                .WithQuality(quality)
                .Build();

            item.Invoking(i => i.UpdateQuality())
                .Should()
                .Throw<Exception>();
        }
    }
}
