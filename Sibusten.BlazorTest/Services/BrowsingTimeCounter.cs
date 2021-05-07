using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Sibusten.BlazorTest.Models;

namespace Sibusten.BlazorTest.Services
{
    public class BrowsingTimeCounter : IDisposable
    {
        private const string _browsingTimeKey = "BrowsingTime";

        private Ticker _ticker;
        private BrowsingTime _browsingTime;
        private ILocalStorageService _localStorage;

        public BrowsingTimeCounter(Ticker ticker, BrowsingTime browsingTime, ILocalStorageService localStorage)
        {
            _ticker = ticker;
            _browsingTime = browsingTime;
            _localStorage = localStorage;

            _ticker.OnTick += OnTick;

            // Queue data loading
            Task.Run(LoadData);
        }

        private async Task LoadData()
        {
            // Load browsing time if it exists
            _browsingTime.SecondsBrowsed = await _localStorage.GetItemAsync<int>(_browsingTimeKey);
        }

        private async void OnTick()
        {
            _browsingTime.SecondsBrowsed++;

            await _localStorage.SetItemAsync<int>(_browsingTimeKey, _browsingTime.SecondsBrowsed);
        }

        public void Dispose()
        {
            _ticker.OnTick -= OnTick;
        }
    }
}
