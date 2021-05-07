using System;
using Sibusten.BlazorTest.Models;

namespace Sibusten.BlazorTest.Services
{
    public class BrowsingTimeCounter : IDisposable
    {
        private Ticker _ticker;
        private BrowsingTime _browsingTime;

        public BrowsingTimeCounter(Ticker ticker, BrowsingTime browsingTime)
        {
            _ticker = ticker;
            _browsingTime = browsingTime;

            _ticker.OnTick += OnTick;
        }

        private void OnTick()
        {
            _browsingTime.SecondsBrowsed++;
        }

        public void Dispose()
        {
            _ticker.OnTick -= OnTick;
        }
    }
}
