using TRAININGMANAGER.Shared.Models;
using TRAININGMANAGER.Shared.Parameters;
using TRAININGMANAGER.Backend.Repos;
using Microsoft.AspNetCore.Mvc;
using TRAININGMANAGER.Shared.Dtos;
using TRAININGMANAGER.Backend.Controllers.Assamblers;
using TRAININGMANAGER.Shared.Responses;
using TRAININGMANAGER.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace TRAININGMANAGER.Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TrainerController : BaseController<Trainer, TrainerDto>
    {
        private readonly ITrainerRepo _trainerRepo;
        public TrainerController(TrainerAssambler assembler, ITrainerRepo repo) : base(assembler, repo)
        {
           _trainerRepo = repo;
        }

        [HttpPost("queryparameters")]
        public async Task<IActionResult> GetTrainers(TrainerQueryParametersDto dto)
        {
            TrainerQueryParameters parameters = dto.ToTrainerQueryParameters();
            if (!parameters.ValidYearRange)
            {
                ControllerResponse response = new ControllerResponse();
                response.AppendNewError("A születési év maximuma nagyobb kell legyen a születési év minimumánál!");
                return BadRequest(response);
            }
            else
            {
                if (_trainerRepo is null)
                {
                    ControllerResponse response = new ControllerResponse();
                    response.AppendNewError("A diákok szűrése születési év alapján nem lehetséges");
                    return BadRequest(response);
                }
                else
                {
                    List<Trainer> result = await _trainerRepo.GetTrainers(parameters).ToListAsync();
                    return Ok(result);
                }
            }

        }
    }
}