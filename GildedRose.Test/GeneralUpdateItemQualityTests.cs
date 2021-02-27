using FluentAssertions;
using GildedRose.Model;
using GildedRose.Test.Builders;
using System;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Test
{
    public class GeneralUpdateItemQualityTests
    {
        private readonly IList<IItem> allVariants = new List<IItem>()
        {
            new CommonItem(),
            new LegendaryItem()
        };

        private readonly IList<(IItem, int)> allVariantsAndTheirMaximumAllowedQuality = new List<(IItem, int)>()
        {
            (new CommonItem(), CommonItem.MaximumAllowedQuality),
            (new LegendaryItem(), LegendaryItem.MaximumAllowedQuality)
        };

        [Fact]
        public void Foo()
        {
            foreach (var tuple in allVariantsAndTheirMaximumAllowedQuality)
            {
                var invalidValues = GetInvalidQualityValuesForItem(tuple.Item2);

                foreach (var value in invalidValues)
                {
                    var item = new ItemBuilder(tuple.Item1)
                        .WithQuality(value)
                        .Build();

                    item.Invoking(i => i.UpdateQuality())
                        .Should()
                        .Throw<Exception>();
                }
            }
        }

        [Fact]
        public void UpdateQuality_ItemWithZeroedQuality_ShouldNotLeaveItWithNegativeValue()
        {
            foreach (var variant in allVariants)
            {
                var item = new ItemBuilder(variant)
                    .WithQuality(0)
                    .Build();

                item.UpdateQuality();

                item.Quality.Should().Be(0);
            }
        }

        //[Fact]
        //public void UpdateQuality_ItemWithInvalidQuality_ShouldThrowAnException()
        //{
        //    foreach (var variant in allVariants)
        //    {
        //        var invalidValues = GetInvalidQualityValuesForItem(variant);

        //        foreach (var value in invalidValues)
        //        {
        //            var item = new ItemBuilder(variant)
        //                .WithQuality(value)
        //                .Build();

        //            item.Invoking(i => i.UpdateQuality())
        //                .Should()
        //                .Throw<Exception>();
        //        }
        //    }
        //}

        //TODO: Think of a better way to retrieve these values
        private IList<int> GetInvalidQualityValuesForItem(int maximumAllowedQuality)
        {
            return new List<int>
            {
                maximumAllowedQuality + 5,
                -1,
                -45
            };
        }
    }
}
