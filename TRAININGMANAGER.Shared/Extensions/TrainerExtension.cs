using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAININGMANAGER.Shared.Models;
using TRAININGMANAGER.Shared.Dtos;

namespace TRAININGMANAGER.Shared.Extensions
{
    public static class TrainerExtension
    {
        public static TrainerDto ToDto(this Trainer trainer)
        {
            return new TrainerDto
            {
                Id = trainer.Id,
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                BirthsDay = trainer.BirthsDay,
                Email = trainer.Email,
                CsapatEdzo = trainer.CsapatEdzo,
                EgyeniEdzo = trainer.EgyeniEdzo,
                Asszisztens = trainer.Asszisztens,
                AgeGroupId = trainer.AgeGroupId,
                WorkingTypeId = trainer.WorkingTypeId
            };
        }

        public static Trainer ToModel(this TrainerDto trainerdto)
        {
            return new Trainer
            {
                Id= trainerdto.Id,
                FirstName= trainerdto.FirstName,
                LastName= trainerdto.LastName,
                BirthsDay= trainerdto.BirthsDay,
                Email = trainerdto.Email,
                CsapatEdzo = trainerdto.CsapatEdzo,
                EgyeniEdzo = trainerdto.EgyeniEdzo,
                Asszisztens = trainerdto.Asszisztens,
                AgeGroupId = trainerdto.AgeGroupId,
                WorkingTypeId = trainerdto.WorkingTypeId
            };
        }
    }
}
