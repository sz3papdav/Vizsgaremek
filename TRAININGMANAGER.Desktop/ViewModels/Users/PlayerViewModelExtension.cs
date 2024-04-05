using TRAININGMANAGER.Shared.Parameters;

namespace TRAININGMANAGER.Desktop.ViewModels.Users
{
    public static class PlayerViewModelExtension
    {
        public static PlayerQueryParameters ToPlayerQueryParameters(this PlayersViewModel playersViewModel)
        {
            return new PlayerQueryParameters
            {
                MinYearOfBirth = playersViewModel.FileteredMinBirthYear,
                MaxYearOfBirth = playersViewModel.FilteredMaxBirthYear,
                Name = playersViewModel.SerchedName
            };
        }
    }
}
