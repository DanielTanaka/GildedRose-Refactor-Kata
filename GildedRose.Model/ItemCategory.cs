namespace GildedRose.Model
{
    public enum ItemCategoryEnum
    {
        Common,
        Aged,
        Legendary,
        Conjured
    }

    public class ItemCategory
    {
        public ItemCategoryEnum Id { get; }

        public ItemCategory(ItemCategoryEnum id)
        {
            Id = id;
        }

        public static bool IsCommon(ItemCategory category)
        {
            return category != null && category.Id == ItemCategoryEnum.Common;
        }

        public static bool IsLegendary(ItemCategory category)
        {
            return category != null && category.Id == ItemCategoryEnum.Legendary;
        }

        public static bool IsAged(ItemCategory category)
        {
            return category != null && category.Id == ItemCategoryEnum.Aged;
        }
    }
}
