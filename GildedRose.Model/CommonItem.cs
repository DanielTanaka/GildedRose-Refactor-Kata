using System;

namespace GildedRose.Model
{
    public class CommonItem : IItem
    {
        public static int MaximumAllowedQuality { get => 50; }

        public string Name { get; set; }
        public int SellIn { get; set; }
        public DateTime SellBy { get; set; }
        public int Quality { get; set; }
        
        //TODO: Move this to a 'Use Cases' layer (Clean Architecture)
        //Think of cases in which this could be run more than once. Calculate based on SellBy
        public void UpdateQuality()
        {
            if (Quality > 0)
            {
                if (SellBy < DateTime.Today)
                {
                    //TODO: Give a name for this magic number
                    Quality -= 2;
                }
                else
                {
                    Quality--;
                }
            }
        }
    }
}
