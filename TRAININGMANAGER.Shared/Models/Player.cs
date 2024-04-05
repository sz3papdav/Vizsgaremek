using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAININGMANAGER.Shared.Models
{
    public class Player : IDbEntity<Player>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public string Email { get; set; }
        public bool CsapatEdzo { get; set; }
        public bool EgyeniEdzo { get; set; }
        public bool Asszisztens { get; set; }
        public string WorkingLevels { get; set; }
        public Guid AgeGroupId { get; set; }
        public Guid WorkingTypeId { get; set; }
        public bool HasId => Id != Guid.Empty;
        public string HungarianFullName
        {
            set { }
            get => $"{LastName} {FirstName}";
        }

        public Player(Guid id, string firstName, string lastName, DateTime birthsDay, string email, bool csapatEdzo, bool egyeniEdzo, bool asszisztens, string workingLevels, Guid ageGroupid, Guid workingTypeid)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            Email = email;
            CsapatEdzo = csapatEdzo;
            EgyeniEdzo = egyeniEdzo;
            Asszisztens = asszisztens;
            WorkingLevels = workingLevels;
            AgeGroupId = ageGroupid;
            WorkingTypeId = workingTypeid;
        }

        public Player()
        {
            Id = Guid.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
            Email = string.Empty;
            WorkingLevels = string.Empty;
            AgeGroupId = Guid.Empty;
            WorkingTypeId = Guid.Empty;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {String.Format("{0:yyyy.MM.dd.}", BirthsDay)}) {Email} {CsapatEdzo} {EgyeniEdzo} {Asszisztens} {WorkingLevels}";
        }
    }
}
