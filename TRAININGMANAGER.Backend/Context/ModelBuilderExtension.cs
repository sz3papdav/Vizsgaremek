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
                    FirstName="László",
                    LastName="Farkas",
                    BirthsDay=new DateTime(2005,7,30),
                    Email="laszlo.farkas@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="László",
                    LastName="Kis",
                    BirthsDay=new DateTime(2003,4,16),
                    Email="laszlo.kis@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="Zsolt",
                    LastName="Tóth",
                    BirthsDay=new DateTime(2003,8,20),
                    Email="zsolt.toth@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="Dániel",
                    LastName="Varga",
                    BirthsDay=new DateTime(2004,7,16),
                    Email="daniel.varga@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="László",
                    LastName="Nagy",
                    BirthsDay=new DateTime(2005,7,5),
                    Email="laszlo.nagy@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="Bence",
                    LastName="Szabó",
                    BirthsDay=new DateTime(2004,6,10),
                    Email="bence.szabo@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="Áron",
                    LastName="Papp",
                    BirthsDay=new DateTime(2003,2,12),
                    Email="aron.papp@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="Zsolt",
                    LastName="Szabó",
                    BirthsDay=new DateTime(2003,1,7),
                    Email="zsolt.szabo@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="Dániel",
                    LastName="Kovács",
                    BirthsDay=new DateTime(2003,6,25),
                    Email="daniel.kovacs@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="Bence",
                    LastName="Varga",
                    BirthsDay=new DateTime(2002,5,6),
                    Email="bence.varga@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="Gergő",
                    LastName="Kovács",
                    BirthsDay=new DateTime(2002,11,29),
                    Email="gergo.kovacs@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },

            };

            // Players
            modelBuilder.Entity<Player>().HasData(players);
        }
    }
}
