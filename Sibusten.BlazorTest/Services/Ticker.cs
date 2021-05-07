using System;
using System.Timers;

namespace Sibusten.BlazorTest.Services
{
    public class Ticker : IDisposable
    {
        private Timer _timer;

        public Action OnTick;

        public Ticker()
        {
            _timer = new Timer
            {
                Interval = TimeSpan.FromSeconds(1).TotalMilliseconds,
                AutoReset = true
            };

            _timer.Elapsed += (_, _) => OnTick?.Invoke();

            _timer.Start();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
