using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GildedRose.Test")]
namespace GildedRose.Commons
{
    public static class Clock
    {
        private static DateTime today = DateTime.Today;

        public static DateTime Today 
        { 
            get 
            { 
                return today; 
            } 
            private set
            {
                today = value;
            } 
        }

        internal static void SetTodayDate(DateTime dateTime)
        {
            Today = dateTime.Date;
        }
    }
}
