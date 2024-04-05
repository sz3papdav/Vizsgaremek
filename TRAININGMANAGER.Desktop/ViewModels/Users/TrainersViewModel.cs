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
    public partial class TrainersViewModel : BaseViewModelWithAsyncInitialization
    {
        private readonly ITrainerService? _trainerService;

        [ObservableProperty]
        private ObservableCollection<string> _workingLevels = new(new WorkingLevels().AllWorkingLevels);

        [ObservableProperty]
        private ObservableCollection<Trainer> _trainers = new();

        [ObservableProperty]
        private Trainer _selectedTrainer;

        private string _selectedWorkingLevels = string.Empty;
        public string SelectedWorkingLevels
        {
            get => _selectedWorkingLevels;

            set
            {
                SetProperty(ref _selectedWorkingLevels, value);
                SelectedTrainer.WorkingLevels = _selectedWorkingLevels;
            }
        }

        public uint FileteredMinBirthYear { get; set; } = 0;
        public uint FilteredMaxBirthYear { get; set; } = uint.MaxValue;
        public string SerchedName { get; set; } = string.Empty;

        public TrainersViewModel()
        {
            SelectedTrainer = new Trainer();
            SelectedWorkingLevels = _workingLevels[0];
        }

        public TrainersViewModel(ITrainerService? trainerService)
        {
            SelectedTrainer = new Trainer();

            _trainerService = trainerService;
        }

        [RelayCommand]
        public async Task DoSave(Trainer newTrainer)
        {
            if (_trainerService is not null)
            {
                ControllerResponse result = new();
                if (newTrainer.HasId)
                    result = await _trainerService.UpdateAsync(newTrainer.ToDto());
                else
                    result = await _trainerService.InsertAsync(newTrainer);
                if (!result.HasError)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        void DoNewTrainer()
        {
            SelectedTrainer = new Trainer();
        }

        [RelayCommand]
        private async Task DoSearchingAndFiltering()
        {
            if (_trainerService != null)
            {
                List<Trainer> trainers = await _trainerService.SearchAndFilterTrainersAsync(this.ToTrainerQueryParameters());
                Trainers = new ObservableCollection<Trainer>(trainers);
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
            if (Trainers is not null && Trainers.Any())
            {
                FileteredMinBirthYear = (uint)Trainers.ToList().Select(trainer => trainer.BirthsDay.Year).Min();
                FilteredMaxBirthYear = (uint)Trainers.ToList().Select(trainer => trainer.BirthsDay.Year).Max();
            }
            else
            {
                FileteredMinBirthYear = FilteredMaxBirthYear = (uint)DateTime.Now.Year;
            }
        }

        [RelayCommand]
        public async Task DoRemove(Trainer trainerToDelete)
        {
            if (_trainerService is not null)
            {
                ControllerResponse result = await _trainerService.DeleteAsync(trainerToDelete.Id);
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
            if (_trainerService is not null)
            {
                if (reloadData)
                {
                    List<Trainer> trainers = await _trainerService.SelectAllTrainerAsync();
                    Trainers = new ObservableCollection<Trainer>(trainers);
                }
                SetFilteredMinMaxYear();
            }
        }
    }
}
