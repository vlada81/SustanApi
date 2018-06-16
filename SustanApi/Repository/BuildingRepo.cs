using SustanApi.Models;
using SustanApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SustanApi.Repository
{
    public class BuildingRepo : IDisposable, IBuildingRepository
    {
        private ApplicationDbContext db;

        public BuildingRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Building> GetAll()
        {
            return db.Buildings;
        }

        public async Task<Building> GetById(int? id)
        {
            return await db.Buildings.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task Create(Building building)
        {
            db.Buildings.Add(building);
            await db.SaveChangesAsync();
        }

        public void Update(Building building)
        {
            db.Entry(building).State = EntityState.Modified;
        }

        public async Task Delete(Building building)
        {
            db.Buildings.Remove(building);
            await db.SaveChangesAsync();
        }

        public bool Exists(int? id)
        {
            return db.Buildings.Count(b => b.Id == id) > 0;
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<Apartment> GetApartments()
        {
            return db.Apartments.Include(a => a.Building).Include(u => u.User);
        }
    }
}