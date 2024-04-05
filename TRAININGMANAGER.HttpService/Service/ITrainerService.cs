using TRAININGMANAGER.Shared.Models;
using TRAININGMANAGER.Shared.Dtos;
using TRAININGMANAGER.Shared.Responses;
using TRAININGMANAGER.Shared.Parameters;

namespace TRAININGMANAGER.HttpService.Service
{
    public interface ITrainerService
    {
        public Task<List<Trainer>> SelectAllTrainerAsync();
        public Task<ControllerResponse> UpdateAsync(TrainerDto trainerDto);
        public Task<ControllerResponse> DeleteAsync(Guid id);
        public Task<ControllerResponse> InsertAsync(Trainer trainer);
        public Task<List<Trainer>> SearchAndFilterTrainersAsync(TrainerQueryParameters trainerQueryParameters);
    }
}
