using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Exercise2.ViewModel;

public class MainViewModel : ViewModelBase, IMainViewModel
{
    private IMovieDetailViewModel _movieDetailViewModel;
    private ISideBarViewModel _sideBarViewModel;

    public ISideBarViewModel SideBarViewModel { get { return _sideBarViewModel; }}
    public IMovieDetailViewModel MovieDetailViewModel { get { return _movieDetailViewModel; }}

    public MainViewModel(ISideBarViewModel sideBarViewModel,IMovieDetailViewModel movieDetailViewModel)
    {
        _sideBarViewModel = sideBarViewModel;
        _movieDetailViewModel = movieDetailViewModel;
        this.PropertyChanged += MovieChange;
        
    }
    public void MovieChange(object sender, PropertyChangedEventArgs e)
    {
        Console.WriteLine("was here");
        MovieDetailViewModel.Movie = SideBarViewModel.SelectedMovie;
    }
    public override void Load()
    {
        _sideBarViewModel.Load();
    }
}