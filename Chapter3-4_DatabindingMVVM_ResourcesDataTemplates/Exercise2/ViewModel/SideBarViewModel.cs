using System.Collections.Generic;
using System.ComponentModel;
using Exercise2.Data;
using Exercise2.Model;

namespace Exercise2.ViewModel;

public class SideBarViewModel : ViewModelBase, ISideBarViewModel, INotifyPropertyChanged
{
    private readonly IMovieRepository _movieRepository;
    private IList<Movie> _movieList;
    private Movie _movie;
    public event PropertyChangedEventHandler? PropertyChanged;



    public SideBarViewModel(IMovieRepository movieRepository)
    {
        _movieList = new List<Movie>();
        _movieRepository = movieRepository;
    }

    public IList<Movie> Movies { get { return _movieList; } private set {
        _movieList = value;
        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Movies"));
        } }

    public Movie? SelectedMovie { get { return _movie; } set
        {
            _movie = value;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SelectedMovie"));
        }
    }

    public override void Load()
    {
        Movies = _movieRepository.GetAll();

    }
}