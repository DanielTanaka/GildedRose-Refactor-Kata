namespace GildedRose.Model
{
    public interface IIncreasingQualityItem : IItem
    {
        int QualityIncreasingRate { get; }
    }
}
