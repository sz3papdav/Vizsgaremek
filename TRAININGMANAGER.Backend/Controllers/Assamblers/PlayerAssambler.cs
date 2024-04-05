using TRAININGMANAGER.Shared.Dtos;
using TRAININGMANAGER.Shared.Extensions;
using TRAININGMANAGER.Shared.Models;

namespace TRAININGMANAGER.Backend.Controllers.Assamblers
{
    public class PlayerAssambler : Assambler<Player, PlayerDto>
    {
        public override PlayerDto ToDto(Player model)
        {
            return model.ToDto();
        }

        public override Player ToModel(PlayerDto dto)
        {
            return dto.ToModel();
        }
    }
}
