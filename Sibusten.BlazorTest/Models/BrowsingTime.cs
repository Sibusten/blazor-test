using System.ComponentModel;

namespace Sibusten.BlazorTest.Models
{
    public class BrowsingTime : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int SecondsBrowsed
        {
            get => _secondsBrowsed;
            set
            {
                if (value != _secondsBrowsed)
                {
                    _secondsBrowsed = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondsBrowsed)));
                }
            }
        }
        private int _secondsBrowsed;
    }
}
