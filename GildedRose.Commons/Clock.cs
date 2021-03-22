using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GildedRose.Test")]
namespace GildedRose.Commons
{
    //TODO: Remove commented code and discuss a better design
    public static class Clock
    {
        //public static DateTime Today { get => DateTime.Today; private set { } }

        public static Func<DateTime> Today = () => DateTime.Today;

        //internal static void SetTodayDate(DateTime todayDateTime)
        //{
        //    Today = todayDateTime;
        //}
    }
}
