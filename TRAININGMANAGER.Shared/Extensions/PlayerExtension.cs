using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAININGMANAGER.Shared.Models;
using TRAININGMANAGER.Shared.Dtos;

namespace TRAININGMANAGER.Shared.Extensions
{
    public static class PlayerExtension
    {
        public static PlayerDto ToDto(this Player player)
        {
            return new PlayerDto
            {
                Id = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                BirthsDay = player.BirthsDay,
                Email = player.Email,
                AgeGroupId = player.AgeGroupId,
                WorkingTypeId = player.WorkingTypeId
            };
        }

        public static Player ToModel(this PlayerDto playerdto)
        {
            return new Player
            {
                Id = playerdto.Id,
                FirstName = playerdto.FirstName,
                LastName = playerdto.LastName,
                BirthsDay = playerdto.BirthsDay,
                Email = playerdto.Email,
                AgeGroupId = playerdto.AgeGroupId,
                WorkingTypeId = playerdto.WorkingTypeId
            };
        }
    }
}
