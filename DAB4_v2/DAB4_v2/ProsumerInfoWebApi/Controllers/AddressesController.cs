using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAB4.Models;
using ProsumerInfo;

namespace ProsumerInfoWebApi.Controllers
{
    public class AddressesController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new ProsumerInfoContext());

        // GET: api/Addresses
        public IQueryable<Address> GetAddresses()
        {
            return _unitOfWork.Addresses.GetAll().AsQueryable();
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(Address))]
        public IHttpActionResult GetAddress(int id)
        {
            Address address = _unitOfWork.Addresses.Get(id);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != address.Id)
            {
                return BadRequest();
            }

            Address a = _unitOfWork.Addresses.Get(id);

            if (a == null)
                return NotFound();


            a.City = address.City;
            a.StreetName = address.StreetName;
            a.StreetNumber = address.StreetNumber;

            _unitOfWork.Complete();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Addresses
        [ResponseType(typeof(Address))]
        public IHttpActionResult PostAddress(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.Addresses.Add(address);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = address.Id }, address);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Address))]
        public IHttpActionResult DeleteAddress(int id)
        {
            Address address = _unitOfWork.Addresses.Get(id);
            if (address == null)
            {
                return NotFound();
            }

            _unitOfWork.Addresses.Remove(address);
            _unitOfWork.Complete();

            return Ok(address);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}