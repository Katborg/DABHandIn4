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
    public class ExpectedDatasController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new ProsumerInfoContext());

        // GET: api/ExpectedDatas
        public IQueryable<ExpectedData> GetExpectedDatas()
        {
            return _unitOfWork.ExpectedDatas.GetAll().AsQueryable();
        }

        // GET: api/ExpectedDatas/5
        [ResponseType(typeof(ExpectedData))]
        public IHttpActionResult GetExpectedData(int id)
        {
            ExpectedData expectedData = _unitOfWork.ExpectedDatas.Get(id);
            if (expectedData == null)
            {
                return NotFound();
            }

            return Ok(expectedData);
        }

        // PUT: api/ExpectedDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExpectedData(int id, ExpectedData expectedData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expectedData.Id)
            {
                return BadRequest();
            }


            ExpectedData e = _unitOfWork.ExpectedDatas.Get(id);
            if (e == null)
            {
                return NotFound();
            }

            
            e.Consumption = expectedData.Consumption;
            e.Production = expectedData.Production;
            e.StartTime = expectedData.StartTime;
            e.EndTime = expectedData.EndTime;

            _unitOfWork.Complete();
            
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ExpectedDatas
        [ResponseType(typeof(ExpectedData))]
        public IHttpActionResult PostExpectedData(ExpectedData expectedData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.ExpectedDatas.Add(expectedData);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = expectedData.Id }, expectedData);
        }

        // DELETE: api/ExpectedDatas/5
        [ResponseType(typeof(ExpectedData))]
        public IHttpActionResult DeleteExpectedData(int id)
        {
            ExpectedData expectedData = _unitOfWork.ExpectedDatas.Get(id);
            if (expectedData == null)
            {
                return NotFound();
            }

            _unitOfWork.ExpectedDatas.Remove(expectedData);
            _unitOfWork.Complete();

            return Ok(expectedData);
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