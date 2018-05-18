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
    public class ProsumersController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new ProsumerInfoContext());

        // GET: api/Prosumers
        public IQueryable<Prosumer> GetProsumers()
        {
            return _unitOfWork.Prosumers.GetAll().AsQueryable();
        }

        // GET: api/Prosumers/5
        [ResponseType(typeof(Prosumer))]
        public IHttpActionResult GetProsumer(int id)
        {
            Prosumer prosumer = _unitOfWork.Prosumers.Get(id);
            if (prosumer == null)
            {
                return NotFound();
            }

            return Ok(prosumer);
        }

        // PUT: api/Prosumers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProsumer(int id, Prosumer prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prosumer.Id)
            {
                return BadRequest();
            }

            Prosumer p = _unitOfWork.Prosumers.Get(id);
            if (p == null)
            {
                return NotFound();
            }

            p.SmartMeterDatas = prosumer.SmartMeterDatas;
            p.Address = prosumer.Address;
            p.ExpectedDatas = prosumer.ExpectedDatas;
            p.Name = prosumer.Name;
            p.TokenBalance = prosumer.TokenBalance;
            p.Type = prosumer.Type;

            _unitOfWork.Complete();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Prosumers
        [ResponseType(typeof(Prosumer))]
        public IHttpActionResult PostProsumer(Prosumer prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.Prosumers.Add(prosumer);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = prosumer.Id }, prosumer);
        }

        // DELETE: api/Prosumers/5
        [ResponseType(typeof(Prosumer))]
        public IHttpActionResult DeleteProsumer(int id)
        {
            Prosumer prosumer = _unitOfWork.Prosumers.Get(id);
            if (prosumer == null)
            {
                return NotFound();
            }

            _unitOfWork.Prosumers.Remove(prosumer);
            _unitOfWork.Complete();

            return Ok(prosumer);
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