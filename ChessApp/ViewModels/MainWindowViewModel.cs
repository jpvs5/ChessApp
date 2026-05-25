using ChessApp.Models;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ChessApp.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private Game _game;
        private bool _squareSelected = false;
        private string _srcSquare = "";

        private ObservableCollection<string> _board;
        public ObservableCollection<string> Board {
            get => _board;
            set
            {
                _board = value;
                OnPropertyChanged(nameof(Board));
            }
        }

        public MainWindowViewModel()
        {
            _game = new Game();
            Board = new ObservableCollection<string>(_game.getBoard());
        }

        [RelayCommand]
        public void SelectSquare(string square)
        {
            if (!_squareSelected)
            {
                _srcSquare = square;
                _squareSelected = true;
                return;
            }

            if (_game.makeMove(_srcSquare, square))
            {
                Board = new ObservableCollection<string>(_game.getBoard());
            }

            _squareSelected = false;
            _srcSquare = "";
        }
    }
}
