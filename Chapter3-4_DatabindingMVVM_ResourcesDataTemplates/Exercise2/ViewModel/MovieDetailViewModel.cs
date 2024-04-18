using Exercise2.Command;
using Exercise2.Model;

namespace Exercise2.ViewModel;

public class MovieDetailViewModel : ViewModelBase, IMovieDetailViewModel
{
    private Movie? _movie;
    private bool _hasNoMovie;

    public DelegateCommand GiveFiveStarRatingCommand { get; set; }
    public Movie? Movie { get { return _movie; } set { _movie = value; this.RaisePropertyChanged(); if (value == null) { _hasNoMovie = true; } else { _hasNoMovie = false; } } }
    public bool HasNoMovie { get { return _hasNoMovie; } set { _hasNoMovie = value; this.RaisePropertyChanged(); } }

    public MovieDetailViewModel()
    {
        //this => { (!this.HasNoMovie));
        _hasNoMovie = true;
        GiveFiveStarRatingCommand = new DelegateCommand(
            test =>
            {
                GiveMovie5Stars();
            }
            );
    }
    

    public void GiveMovie5Stars()
    {
        _movie.Rating = 5;
    }

    public override void Load()
    {
        throw new NotImplementedException();
    }
}