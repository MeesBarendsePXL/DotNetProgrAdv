using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Exercise1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public ObservableCollection<Movie> Movies { 
            get { return _movies; }
            set { _movies = value; RaisePropertyChanged(); } }

        public Movie Movie { get { return _newMovie; } set { _newMovie = value; RaisePropertyChanged(); } }

        private Movie _newMovie = new Movie();
        private ObservableCollection<Movie> _movies = new ObservableCollection<Movie>();

        public MainWindow()
        {
            DataContext = this;

            foreach (Movie movie in GetDummyMovies())
            {
                _movies.Add(movie);
            };

            InitializeComponent();
        }

        private IList<Movie> GetDummyMovies()
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    Title = "The Godfather",
                    Director = "Francis Ford Coppola",
                    ReleaseYear = 1972
                },
                new Movie
                {
                    Title = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    ReleaseYear = 1994
                }
            };
            return movies;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddNewMovieButton_Click(object sender, RoutedEventArgs e)
        {
            Movie template = new Movie();
            if (_newMovie.Title == template.Title || _newMovie.ReleaseYear == template.ReleaseYear || _newMovie.Director == template.Director)
            {
                ErrorMessageTextBlock.Text = "Title can not be empty";
                return;
            }
            _movies.Add(_newMovie);
            
            
            Movie = template;

            ErrorMessageTextBlock.Text = String.Empty;
            RaisePropertyChanged();
        }
    }
}