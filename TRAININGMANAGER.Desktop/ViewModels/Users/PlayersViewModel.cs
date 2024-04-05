using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TRAININGMANAGER.desktop.ViewModels.Base;
using TRAININGMANAGER.HttpService.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TRAININGMANAGER.Shared.Models;
using TRAININGMANAGER.Shared.Extensions;
using TRAININGMANAGER.Shared.Responses;

namespace TRAININGMANAGER.Desktop.ViewModels.Users
{
    public partial class PlayersViewModel : BaseViewModelWithAsyncInitialization
    {
        private readonly IPlayerService? _playerService;

        [ObservableProperty]
        private ObservableCollection<string> _workingLevels = new(new WorkingLevels().AllWorkingLevels);

        [ObservableProperty]
        private ObservableCollection<Player> _players = new();

        [ObservableProperty]
        private Player _selectedPlayer;

        private string _selectedWorkingLevels = string.Empty;
        public string SelectedWorkingLevels
        {
            get => _selectedWorkingLevels;

            set
            {
                SetProperty(ref _selectedWorkingLevels, value);
                SelectedPlayer.WorkingLevels = _selectedWorkingLevels;
            }
        }

        public uint FileteredMinBirthYear { get; set; } = 0;
        public uint FilteredMaxBirthYear { get; set; } = uint.MaxValue;
        public string SerchedName { get; set; } = string.Empty;

        public PlayersViewModel()
        {
            SelectedPlayer = new Player();
            SelectedWorkingLevels = _workingLevels[0];
        }

        public PlayersViewModel(IPlayerService? playerService)
        {
            SelectedPlayer = new Player();

            _playerService = playerService;
        }

        [RelayCommand]
        public async Task DoSave(Player newPlayer)
        {
            if (_playerService is not null)
            {
                ControllerResponse result = new();
                if (newPlayer.HasId)
                    result = await _playerService.UpdateAsync(newPlayer.ToDto());
                else
                    result = await _playerService.InsertAsync(newPlayer);
                if (!result.HasError)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        void DoNewPlayer()
        {
            SelectedPlayer = new Player();
        }

        [RelayCommand]
        private async Task DoSearchingAndFiltering()
        {
            if (_playerService != null)
            {
                List<Player> players = await _playerService.SearchAndFilterPlayersAsync(this.ToPlayerQueryParameters());
                Players = new ObservableCollection<Player>(players);
                await UpdateView(false);
            }
        }

        [RelayCommand]
        private async Task DoResetFilterAndSerachParameter()
        {
            SerchedName = string.Empty;
            FileteredMinBirthYear = 0;
            FilteredMaxBirthYear = uint.MaxValue;
            await InitializeAsync();
        }

        private void SetFilteredMinMaxYear()
        {
            if (Players is not null && Players.Any())
            {
                FileteredMinBirthYear = (uint)Players.ToList().Select(player => player.BirthsDay.Year).Min();
                FilteredMaxBirthYear = (uint)Players.ToList().Select(player => player.BirthsDay.Year).Max();
            }
            else
            {
                FileteredMinBirthYear = FilteredMaxBirthYear = (uint)DateTime.Now.Year;
            }
        }

        [RelayCommand]
        public async Task DoRemove(Player playerToDelete)
        {
            if (_playerService is not null && playerToDelete is not null)
            {
                ControllerResponse result = await _playerService.DeleteAsync(playerToDelete.Id);
                if (!result.HasError)
                {
                    await UpdateView();
                }
            }
        }

        public override async Task InitializeAsync()
        {
            await UpdateView();
        }

        private async Task UpdateView(bool reloadData = true)
        {
            if (_playerService is not null)
            {
                if (reloadData)
                {
                    List<Player> players = await _playerService.SelectAllPlayerAsync();
                    Players = new ObservableCollection<Player>(players);
                }
                SetFilteredMinMaxYear();
            }
        }
    }
}
