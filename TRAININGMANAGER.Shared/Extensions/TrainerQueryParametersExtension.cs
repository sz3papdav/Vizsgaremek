using TRAININGMANAGER.Shared.Dtos;
using TRAININGMANAGER.Shared.Parameters;

namespace TRAININGMANAGER.Shared.Extensions
{
    public static class TrainerQueryParametersExtension
    {
        public static TrainerQueryParametersDto ToDto(this TrainerQueryParameters parameters)
        {
            return new TrainerQueryParametersDto
            {
                MaxYearOfBirth = parameters.MaxYearOfBirth,
                MinYearOfBirth = parameters.MinYearOfBirth,
                Name = parameters.Name,
            };
        }

        public static TrainerQueryParameters ToTrainerQueryParameters(this TrainerQueryParametersDto parameters)
        {
            return new TrainerQueryParameters
            {
                MinYearOfBirth = parameters.MinYearOfBirth,
                MaxYearOfBirth = parameters.MaxYearOfBirth,
                Name = parameters.Name,
            };
        }
    }
}
