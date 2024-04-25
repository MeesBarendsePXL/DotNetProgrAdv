using DartApp.AppLogic;
using DartApp.AppLogic.Contracts;
using DartApp.Domain;
using DartApp.Domain.Contracts;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace DartApp.Presentation
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public ObservableCollection<IPlayer> AllPlayers { get; set; }

        public Visibility ShowSelectedPlayer => SelectedPlayer == null ? Visibility.Hidden : Visibility.Visible;

        public IPlayer? SelectedPlayer { get { return _selectedPlayer; } set { _selectedPlayer = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SelectedPlayer"));
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ShowSelectedPlayer"));

            } }
        private IPlayer? _selectedPlayer { get; set; }

        public IPlayerStats? PlayerStats { get; set; }

        private IPlayerService _playerService;

        public MainWindow(IPlayerService playerService)
        {

            this.DataContext = this;
            InitializeComponent();
            AllPlayers = new ObservableCollection<IPlayer>(playerService.GetAllPlayers());
            _playerService = playerService;
            foreach (var item in AllPlayers)
            {
                PlayerComboBox.Items.Add(item);

            }



        }

        private void OnPlayerSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPlayer = PlayerComboBox.SelectedItem as IPlayer;
        }

        private void OnAddPlayerClick(object sender, RoutedEventArgs e)
        {
            SelectedPlayer = _playerService.AddPlayer(PlayerNameTextBox.Text);
            AllPlayers.Add(SelectedPlayer);
            PlayerNameTextBox.Text = String.Empty;
        }

        private void OnAddGameResultClick(object sender, RoutedEventArgs e)
        {
            _playerService.AddGameResultForPlayer(SelectedPlayer,int.Parse(GameResultNumberOf180TextBox.Text) , Double.Parse(GameResultAverageTextBox.Text),int.Parse(GameResultBestThrowTextBox.Text));
            GameResultBestThrowTextBox.Text = String.Empty;
            GameResultNumberOf180TextBox.Text = String.Empty;
            GameResultAverageTextBox.Text = String.Empty;


            PlayerStats = _playerService.GetStatsForPlayer(SelectedPlayer);
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("PlayerStats"));


        }

        private void OnCalculateStats(object sender, RoutedEventArgs e)
        {
            PlayerStats = _playerService.GetStatsForPlayer(SelectedPlayer);
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("PlayerStats"));
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
