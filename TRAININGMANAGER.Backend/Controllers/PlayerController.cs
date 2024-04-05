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
    public class PlayerController : BaseController<Player, PlayerDto>
    {
        private readonly IPlayerRepo _playerRepo;
        public PlayerController(PlayerAssambler assembler, IPlayerRepo repo) : base(assembler, repo)
        {
            _playerRepo = repo;
        }

        [HttpPost("queryparameters")]
        public async Task<IActionResult> GetPlayers(PlayerQueryParametersDto dto)
        {
            PlayerQueryParameters parameters = dto.ToPlayerQueryParameters();
            if (!parameters.ValidYearRange)
            {
                ControllerResponse response = new ControllerResponse();
                response.AppendNewError("A születési év maximuma nagyobb kell legyen a születési év minimumánál!");
                return BadRequest(response);
            }
            else
            {
                if (_playerRepo is null)
                {
                    ControllerResponse response = new ControllerResponse();
                    response.AppendNewError("A diákok szűrése születési év alapján nem lehetséges");
                    return BadRequest(response);
                }
                else
                {
                    List<Player> result = await _playerRepo.GetTrainers(parameters).ToListAsync();
                    return Ok(result);
                }
            }

        }
    }
}
