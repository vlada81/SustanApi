using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using SustanApi.Models;
using SustanApi.Repository;
using SustanApi.Repository.Interfaces;

namespace SustanApi.Controllers
{
    //[Authorize]
    public class ApartmentsController : ApiController
    {
        private IApartmentRepository _repository { get; set; }

        public ApartmentsController()
        {
            _repository = new ApartmentRepo(new ApplicationDbContext());
        }

        public ApartmentsController(IApartmentRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Apartments
        //[ResponseType(typeof(Apartment))]
        [AllowAnonymous]
        public IEnumerable<Apartment> GetApartments()
        {
            return _repository.GetAll();
        }

        // GET: api/Apartments/List
        [ResponseType(typeof(Apartment))]
        [Route("user")]
        public IQueryable<Apartment> GetApartmentsByUserId()
        {
            var currentUser = User.Identity.GetUserId();

            return _repository.GetApartmentsByUserId(currentUser);
        }

        // GET: api/Apartments/5
        [ResponseType(typeof(Apartment))]
        public async Task<IHttpActionResult> GetApartment(int id)
        {
            Apartment apartment = await _repository.GetById(id);
            if (apartment == null)
            {
                return NotFound();
            }

            return Ok(apartment);
        }

        // POST: api/Buildings
        [ResponseType(typeof(Apartment))]
        public async Task<IHttpActionResult> PostApartment(Apartment apartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.Create(apartment);

            return CreatedAtRoute("DefaultApi", new { id = apartment.Id }, apartment);
        }

        // PUT: api/Apartments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApartment(int id, Apartment apartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apartment.Id)
            {
                return BadRequest();
            }

            _repository.Update(apartment);

            try
            {
                await _repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(apartment);
        }

        // DELETE: api/Apartments/5
        [ResponseType(typeof(Apartment))]
        public async Task<IHttpActionResult> DeleteApartment(int id)
        {
            Apartment apartment = await _repository.GetById(id);
            if (apartment == null)
            {
                return NotFound();
            }

            await _repository.Delete(apartment);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
