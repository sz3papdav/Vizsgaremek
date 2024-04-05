using TRAININGMANAGER.Shared.Dtos;
using TRAININGMANAGER.Shared.Extensions;
using TRAININGMANAGER.Shared.Models;

namespace TRAININGMANAGER.Backend.Controllers.Assamblers
{
    public class TrainerAssambler : Assambler<Trainer, TrainerDto>
    {
        public override TrainerDto ToDto(Trainer model)
        {
            return model.ToDto();
        }

        public override Trainer ToModel(TrainerDto dto)
        {
            return dto.ToModel();
        }
    }
}
