using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FontAwesome.Sharp;
using TRAININGMANAGER.Desktop.ViewModels.Base;
using TRAININGMANAGER.Desktop.ViewModels.ControlPanel;
using TRAININGMANAGER.Desktop.ViewModels.Users;

namespace TRAININGMANAGER.Desktop.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private ControlPanelViewModel _controlPanelViewModel;
        private UsersViewModel _usersViewModel;
        private PlayersViewModel _playersViewModel;

        public MainViewModel()
        {
            _controlPanelViewModel = new ControlPanelViewModel();
            _usersViewModel = new UsersViewModel();
            _playersViewModel = new PlayersViewModel();

            _currentChildView = _controlPanelViewModel;
        }

        public MainViewModel(
            ControlPanelViewModel controlPanelViewModel,
            UsersViewModel usersViewModel,
            PlayersViewModel playersViewModel
            )
        {
            _controlPanelViewModel = controlPanelViewModel;
            _usersViewModel = usersViewModel;
            _playersViewModel = playersViewModel;


            CurrentChildView = _controlPanelViewModel;
            ShowDashbord();
        }

        [ObservableProperty]
        private string _caption = string.Empty;

        [ObservableProperty]
        private IconChar _icon = new IconChar();

        [ObservableProperty]
        private BaseViewModel _currentChildView;

        [RelayCommand]
        public void ShowDashbord()
        {
            Caption = "Vezérlőpult";
            Icon=IconChar.SolarPanel;
            CurrentChildView = _controlPanelViewModel;
        }

        [RelayCommand]
        public void ShowUsers()
        {
            Caption = "Felhasználók";
            Icon = IconChar.UserGroup;
            CurrentChildView = _usersViewModel;
        }
    }
}
