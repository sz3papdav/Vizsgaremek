using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TRAININGMANAGER.Desktop.ViewModels.Base;
using System.Threading.Tasks;
using TRAININGMANAGER.HttpService.Service;
using System.Net.Http;

namespace TRAININGMANAGER.Desktop.ViewModels.Users
{
    public partial class UsersViewModel : BaseViewModel
    {
        private readonly PlayersViewModel _playersViewModel;
        private readonly TrainersViewModel _trainersViewModel;

        public UsersViewModel()
        {
            _currentPlayersChildView = new PlayersViewModel();
            _playersViewModel = new PlayersViewModel();

            ITrainerService trainerService = new TrainerService(null);
            _trainersViewModel = new TrainersViewModel(trainerService);
        }

        public UsersViewModel(PlayersViewModel playersViewModel, TrainersViewModel trainersViewModel)
        {
            _playersViewModel = playersViewModel;
            _trainersViewModel = trainersViewModel;

            _currentPlayersChildView = new PlayersViewModel();
        }

        [ObservableProperty]
        private BaseViewModel _currentPlayersChildView;


        [RelayCommand]
        public async Task ShowPlayersView()
        {
            await _playersViewModel.InitializeAsync();
            CurrentPlayersChildView = _playersViewModel;
        }


        [RelayCommand]
        public async Task ShowTrainersView()
        {
            await _trainersViewModel.InitializeAsync();
            CurrentPlayersChildView = _trainersViewModel;
        }
    }
}
