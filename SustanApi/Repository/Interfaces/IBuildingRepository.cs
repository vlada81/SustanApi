using SustanApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustanApi.Repository.Interfaces
{
    public interface IBuildingRepository
    {
        IQueryable<Building> GetAll();
        Task<Building> GetById(int? id);
        Task Create(Building building);
        void Update(Building building);
        Task Delete(Building building);
        Task Save();
        bool Exists(int? id);

        IQueryable<Apartment> GetApartments();
    }
}
