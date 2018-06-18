using SustanApi.Models;
using SustanApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustanApi.Repository.Interfaces
{
    public interface IApartmentRepository
    {
        IEnumerable<Apartment> GetAll();
        Task<Apartment> GetById(int? id);
        IQueryable<Apartment> GetApartmentsByUserId(string id);
        Task Create(Apartment apartment);
        void Update(Apartment apartment);
        Task Delete(Apartment apartment);
        Task Save();
        bool Exists(int? id);

        //IQueryable<Building> GetBuildings();
        //IQueryable<ApplicationUser> GetUsers();
    }
}
