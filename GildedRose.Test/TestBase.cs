using GildedRose.Commons;
using System;

namespace GildedRose.Test
{
    public abstract class TestBase : IDisposable
    {
        //XUnit Teardown. This method gets called after every test is finished
        public void Dispose()
        {
            Clock.Today = () => DateTime.Today;
        }
    }
}
