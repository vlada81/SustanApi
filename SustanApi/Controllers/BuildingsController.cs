using SustanApi.Models;
using SustanApi.Repository;
using SustanApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace SustanApi.Controllers
{
    public class BuildingsController : ApiController
    {
        private IBuildingRepository _repository { get; set; }

        public BuildingsController()
        {
            _repository = new BuildingRepo(new ApplicationDbContext());
        }

        public BuildingsController(IBuildingRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Buildings
        public IQueryable<Building> GetBuilding()
        {
            return _repository.GetAll();
        }

        // GET: api/Buildings/5
        [ResponseType(typeof(Building))]
        public async Task<IHttpActionResult> GetBuilding(int id)
        {
            Building building = await _repository.GetById(id);
            if (building == null)
            {
                return NotFound();
            }

            return Ok(building);
        }

        // POST: api/Buildings
        [ResponseType(typeof(Building))]
        public async Task<IHttpActionResult> PostBuilding(Building building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.Create(building);

            return CreatedAtRoute("DefaultApi", new { id = building.Id }, building);
        }

        // PUT: api/Buildings/5
        [ResponseType(typeof(Building))]
        public async Task<IHttpActionResult> PutBuilding(int id, Building building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != building.Id)
            {
                return BadRequest();
            }

            _repository.Update(building);

            try
            {
                await _repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_repository.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return Ok(building);
        }

        // DELETE: api/Buildings/5
        [ResponseType(typeof(Building))]
        public async Task<IHttpActionResult> DeleteBuilding(int id)
        {
            Building building = await _repository.GetById(id);
            if (building == null)
            {
                return NotFound();
            }

            await _repository.Delete(building);

            return StatusCode(HttpStatusCode.NoContent);
        }


    }
}
