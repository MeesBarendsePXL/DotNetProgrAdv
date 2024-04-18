using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Exercise2.Model
{
    public class Movie : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string OpeningCrawl { get; set; }

        public int Rating { get { return _rating; } set {

                if (value <= 1) {
                    _rating = 1;
                
                }
                else if (value > 5) {
                     _rating = 5;

                }
                else
                {
                    _rating = value;
                }
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Rating"));
            }
        }

        private int _rating;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Movie()
        {
            Title = String.Empty;
            OpeningCrawl = String.Empty;
            _rating = 1;
        }
    }
}
