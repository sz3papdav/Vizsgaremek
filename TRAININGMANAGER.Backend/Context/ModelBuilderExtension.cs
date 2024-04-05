using TRAININGMANAGER.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace TRAININGMANAGER.Backend.Context
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<Trainer> trainers = new List<Trainer>
            {
                new Trainer
                {
                    Id=Guid.NewGuid(),
                    FirstName="Zsolt",
                    LastName="Kiss",
                    BirthsDay=new DateTime(1989,7,10),
                    Email="kiss.zsolt@gmail.com",
                    CsapatEdzo=true,
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Trainer
                {
                    Id=Guid.NewGuid(),
                    FirstName="Anita",
                    LastName="Nagy",
                    BirthsDay=new DateTime(1992,2,23),
                    Email="nagyanita0223@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    EgyeniEdzo=true,
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Trainer
                {
                    Id=Guid.NewGuid(),
                    FirstName="Béla",
                    LastName="Erdős",
                    BirthsDay=new DateTime(2000,11,15),
                    Email="erdosbela01@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    Asszisztens=true,
                    WorkingTypeId=Guid.NewGuid(),
                },
            };

            // Trainers
            modelBuilder.Entity<Trainer>().HasData(trainers);


            List<Player> players = new List<Player>
            {
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="Cigány",
                    LastName="Zsolt",
                    BirthsDay=new DateTime(1989,7,10),
                    Email="farago.zsolt@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="Nagy",
                    LastName="Anita",
                    BirthsDay=new DateTime(1992,2,23),
                    Email="nagyanita0223@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="Lakatos",
                    LastName="Béla",
                    BirthsDay=new DateTime(2000,11,15),
                    Email="lakbela@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="Kiss",
                    LastName="László",
                    BirthsDay=new DateTime(1988,12,1),
                    Email="farago1998@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="Szekeres",
                    LastName="Brigitta",
                    BirthsDay=new DateTime(2002,4,30),
                    Email="brigitta.szekeres@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                }
            };

            // Players
            modelBuilder.Entity<Player>().HasData(players);
        }
    }
}
