using SustanApi.Models;
using SustanApi.Repository.Interfaces;
using SustanApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SustanApi.Repository
{
    public class ApartmentRepo : IDisposable, IApartmentRepository
    {
        private ApplicationDbContext db;

        public ApartmentRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Apartment> GetAll()
        {
            return db.Apartments.Include(b => b.Building);
        }

        public async Task<Apartment> GetById(int? id)
        {
            return await db.Apartments.Include(a => a.Building).SingleOrDefaultAsync(a => a.Id == id);
        }

        public IQueryable<Apartment> GetApartmentsByUserId(string id) 
        {
            return db.Apartments.Include(u => u.User).Where(a => a.UserId == id).Include(a => a.Building);
        }

        public async Task Create(Apartment apartment)
        {
            db.Apartments.Add(apartment);
            await db.SaveChangesAsync();
        }

        public void Update(Apartment apartment)
        {
            db.Entry(apartment).State = EntityState.Modified;
        }

        public async Task Delete(Apartment apartment)
        {
            db.Apartments.Remove(apartment);
            await db.SaveChangesAsync();
        }

        public bool Exists(int? id)
        {
            return db.Apartments.Include(a => a.Building).Include(a => a.User).Count(a => a.Id == id) > 0;
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

        //public IQueryable<Building> GetBuildings()
        //{
        //    return db.Buildings;
        //}

        //public IQueryable<ApplicationUser> GetUsers()
        //{
        //    return db.Users;
        //}
    }
}