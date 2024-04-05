using TRAININGMANAGER.Shared.Dtos;
using TRAININGMANAGER.Shared.Parameters;

namespace TRAININGMANAGER.Shared.Extensions
{
    public static class PlayerQueryParametersExtension
    {
        public static PlayerQueryParametersDto ToDto(this PlayerQueryParameters parameters)
        {
            return new PlayerQueryParametersDto
            {
                MaxYearOfBirth = parameters.MaxYearOfBirth,
                MinYearOfBirth = parameters.MinYearOfBirth,
                Name = parameters.Name,
            };
        }

        public static PlayerQueryParameters ToPlayerQueryParameters(this PlayerQueryParametersDto parameters)
        {
            return new PlayerQueryParameters
            {
                MinYearOfBirth = parameters.MinYearOfBirth,
                MaxYearOfBirth = parameters.MaxYearOfBirth,
                Name = parameters.Name,
            };
        }
    }
}
