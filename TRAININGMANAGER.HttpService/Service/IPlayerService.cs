using TRAININGMANAGER.Shared.Models;
using TRAININGMANAGER.Shared.Dtos;
using TRAININGMANAGER.Shared.Responses;
using TRAININGMANAGER.Shared.Parameters;

namespace TRAININGMANAGER.HttpService.Service
{
    public interface IPlayerService
    {
        public Task<List<Player>> SelectAllPlayerAsync();
        public Task<ControllerResponse> UpdateAsync(PlayerDto playerDto);
        public Task<ControllerResponse> DeleteAsync(Guid id);
        public Task<ControllerResponse> InsertAsync(Player player);
        public Task<List<Player>> SearchAndFilterPlayersAsync(PlayerQueryParameters playerQueryParameters);
    }
}
