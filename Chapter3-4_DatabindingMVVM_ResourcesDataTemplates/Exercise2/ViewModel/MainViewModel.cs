using System.ComponentModel;

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

       // PropertyChanged = () => { MovieDetailViewModel.Movie = SideBarViewModel.SelectedMovie; };
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    public override void Load()
    {
        _sideBarViewModel.Load();
    }
}