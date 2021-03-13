using FluentAssertions;
using GildedRose.Model;
using GildedRose.Service.API;
using GildedRose.Service.API.Exceptions;
using GildedRose.Service.Impl;
using GildedRose.Test.Builders;
using System;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Test
{
    public class GeneralUpdateItemQualityTests
    {
        private readonly IItemService itemService;

        public GeneralUpdateItemQualityTests()
        {
            itemService = new ItemService();
        }

        //TODO: Include new types
        private readonly IList<IItem> allItemVariants = new List<IItem>
        {
            new CommonItem(),
            new LegendaryItem()
        };

        [Fact]
        public void UpdateQuality_ItemWithQualityOutOfRange_ShouldThrowAnException()
        {
            foreach (var variant in allItemVariants)
            {
                var invalidValues = GetInvalidQualityValues(variant.MaximumAllowedQuality);

                foreach (var value in invalidValues)
                {
                    var item = new ItemBuilder(variant)
                        .WithDefaultValues()
                        .WithQuality(value)
                        .Build();

                    itemService.Invoking(i => i.UpdateItemQuality(item))
                        .Should()
                        .Throw<QualityOutOfRangeException>();
                }
            }
        }

        private IList<int> GetInvalidQualityValues(int itemMaximumAllowedQuality)
        {
            return new List<int>
            {
                itemMaximumAllowedQuality + 1,
                -1,
                -45
            };
        }

        [Fact]
        public void UpdateQuality_ItemWithZeroedQuality_ShouldNotLeaveItWithNegativeValue()
        {
            foreach (var variant in allItemVariants)
            {
                var item = new ItemBuilder(variant)
                    .WithDefaultValues()
                    .WithQuality(0)
                    .Build();

                itemService.UpdateItemQuality(item);

                item.Quality.Should().Be(0);
            }
        }

        [Fact]
        public void UpdateQuality_WithUpdateQualityLastRanSetAsToday_ShouldNotUpdateQuality()
        {
            foreach (var variant in allItemVariants)
            {
                var item = new ItemBuilder(variant)
                        .WithDefaultValues()
                        .WithLastQualityCheckUp(DateTime.Today)
                        .Build();
                var previousItemQuality = item.Quality;

                itemService.UpdateItemQuality(item);

                item.Quality.Should().Be(previousItemQuality); 
            }
        }

        [Fact]
        public void UpdateQuality_WithUpdateQualityLastRanSetInTheFuture_ShouldThrownAnException()
        {
            foreach (var variant in allItemVariants)
            {
                var item = new ItemBuilder(variant)
                        .WithDefaultValues()
                        .WithLastQualityCheckUp(DateTime.Today.AddDays(1))
                        .Build();

                itemService.Invoking(i => i.UpdateItemQuality(item))
                    .Should()
                    .Throw<Exception>()
                    .WithMessage($"Item cannot have its {nameof(item.LastQualityCheckUp)} in the future"); 
            }
        }

        [Fact]
        public void UpdateQuality_WithUpdateQualityLastRanSetInThePast_ShouldSetUpdateQualityLastRanAsToday()
        {
            foreach (var variants in allItemVariants)
            {
                var item = new ItemBuilder(variants)
                    .WithDefaultValues()
                    .WithLastQualityCheckUp(DateTime.Today.AddDays(-1))
                    .Build();

                itemService.UpdateItemQuality(item);

                item.LastQualityCheckUp.Should().Be(DateTime.Today);
            }
        }
    }
}
