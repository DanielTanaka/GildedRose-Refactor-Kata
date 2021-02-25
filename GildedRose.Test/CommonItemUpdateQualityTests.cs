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

        [Theory]
        //TODO: Create a method that knows all values to test these invalid cases
        //TODO: Extract these generic tests (that are applicable to every 'item type' in a separated class)
        //Instantiate each one so we test... each one
        [InlineData(55)]
        [InlineData(-1)]
        public void UpdateQuality_ItemWithInvalidQuality_ShouldThrowAnException(int quality)
        {
            var item = new ItemBuilder(new CommonItem())
                .WithQuality(quality)
                .Build();

            item.Invoking(i => i.UpdateQuality())
                .Should()
                .Throw<Exception>();
        }

        [Fact]
        public void UpdateQuality_ItemWithZeroedQuality_ShouldNotLeaveItWithNegativeValue()
        {
            var item = new ItemBuilder(new CommonItem())
                .WithQuality(0)
                .Build();

            item.UpdateQuality();

            item.Quality.Should().Be(0);
        }
    }
}
