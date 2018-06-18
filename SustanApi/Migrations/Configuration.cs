namespace SustanApi.Migrations
{
    using SustanApi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SustanApi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SustanApi.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

           
            context.Buildings.AddOrUpdate(b => b.Id,
                new Building() { Id = 1, JIBZ = "72-12", Street = "Sigmunda Frojda", Number = 8, Entrance = null, NumberOfFloors = 6, Pib = 800650790, BuildingRegistrationNumber = 54012388, AccountNumber = "205-0000015002030-55", AccountBalance = 560200.50m, ParcelNumber = "1025", BuildingArea = 756.52m, BuildingManager = "Petar Petrovic" },
                new Building() { Id = 2, JIBZ = "54-02", Street = "Cara Lazara", Number = 25, Entrance = "II", NumberOfFloors = 8, Pib = 682000123, BuildingRegistrationNumber = 33785214, AccountNumber = "205-0000501002050-55", AccountBalance = 185003.20m, ParcelNumber = "1403", BuildingArea = 890.54m, BuildingManager = "Mika Mikan" },
                new Building() { Id = 3, JIBZ = "33-08", Street = "Kralja Petra", Number = 2, Entrance = null, NumberOfFloors = 6, Pib = 682000124, BuildingRegistrationNumber = 33785222, AccountNumber = "205-0000308002010-55", AccountBalance = 285003.20m, ParcelNumber = "1411", BuildingArea = 990.54m, BuildingManager = "Milica Pupin" }
                );

            context.Apartments.AddOrUpdate(a => a.Id,
                new Apartment() { JIBS = "54-02-03", ApartmentNumber = 3, ApartmentArea = 82.50m, NumberOfTenants = 4, CostOfService = 240.00m, BuildingId = 2, UserId = "078af1fd-5dcd-4bd1-b852-b1e2e6f73f4b" },
                new Apartment() { JIBS = "72-12-01", ApartmentNumber = 1, ApartmentArea = 56.00m, NumberOfTenants = 3, CostOfService = 320.00m, BuildingId = 1, UserId = "ee041b4d-925f-45f6-9048-255b77a4d4c4" },
                new Apartment() { JIBS = "72-12-04", ApartmentNumber = 4, ApartmentArea = 32.80m, NumberOfTenants = 1, CostOfService = 320.00m, BuildingId = 1, UserId = "078af1fd-5dcd-4bd1-b852-b1e2e6f73f4b" },
                new Apartment() { JIBS = "33-08-07", ApartmentNumber = 7, ApartmentArea = 36.00m, NumberOfTenants = 1, CostOfService = 280.00m, BuildingId = 3, UserId = null }

                );
        }
    }
}
