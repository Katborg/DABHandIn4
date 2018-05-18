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
    public class SmartMeterDatasController : ApiController
    {
         private UnitOfWork _unitOfWork = new UnitOfWork(new ProsumerInfoContext());

        // GET: api/SmartMeterDatas
        public IQueryable<SmartMeterData> GetSmartMeterDatas()
        {
            return _unitOfWork.SmartMeterDatas.GetAll().AsQueryable();
        }

        // GET: api/SmartMeterDatas/5
        [ResponseType(typeof(SmartMeterData))]
        public IHttpActionResult GetSmartMeterData(int id)
        {
            SmartMeterData smartMeterData = _unitOfWork.SmartMeterDatas.Get(id);
            if (smartMeterData == null)
            {
                return NotFound();
            }

            return Ok(smartMeterData);
        }

        // PUT: api/SmartMeterDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSmartMeterData(int id, SmartMeterData smartMeterData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smartMeterData.Id)
            {
                return BadRequest();
            }

            SmartMeterData s = _unitOfWork.SmartMeterDatas.Get(id);
            if (s == null)
            {
                return NotFound();
            }


            s.Consumed = smartMeterData.Consumed;
            s.Produced = smartMeterData.Produced;
            s.StartTime = smartMeterData.StartTime;
            s.EndTime = smartMeterData.EndTime;

            _unitOfWork.Complete();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SmartMeterDatas
        [ResponseType(typeof(SmartMeterData))]
        public IHttpActionResult PostSmartMeterData(SmartMeterData smartMeterData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.SmartMeterDatas.Add(smartMeterData);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = smartMeterData.Id }, smartMeterData);
        }

        // DELETE: api/SmartMeterDatas/5
        [ResponseType(typeof(SmartMeterData))]
        public IHttpActionResult DeleteSmartMeterData(int id)
        {
            SmartMeterData smartMeterData = _unitOfWork.SmartMeterDatas.Get(id);
            if (smartMeterData == null)
            {
                return NotFound();
            }

            _unitOfWork.SmartMeterDatas.Remove(smartMeterData);
            _unitOfWork.Complete();

            return Ok(smartMeterData);
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