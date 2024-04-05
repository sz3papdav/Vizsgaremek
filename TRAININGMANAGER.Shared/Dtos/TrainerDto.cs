using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAININGMANAGER.Shared.Dtos
{
    public class TrainerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public string Email { get; set; }
        public bool CsapatEdzo { get; set; }
        public bool EgyeniEdzo { get; set; }
        public bool Asszisztens { get; set; }
        public Guid AgeGroupId { get; set; }
        public Guid WorkingTypeId { get; set; }

        public TrainerDto(Guid id, string firstName, string lastName, DateTime birthsDay, string email, bool csapatEdzo, bool egyeniEdzo, bool asszisztens, Guid ageGroupid, Guid workingTypeid)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            Email = email;
            AgeGroupId = ageGroupid;
            WorkingTypeId = workingTypeid;
            CsapatEdzo = csapatEdzo;
            EgyeniEdzo = egyeniEdzo;
            Asszisztens = asszisztens;
        }

        public TrainerDto()
        {
            Id = Guid.NewGuid();
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
            Email = string.Empty;
            AgeGroupId = Guid.NewGuid();
            WorkingTypeId = Guid.NewGuid();
        }
    }
}
