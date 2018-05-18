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
using TraderInfo;

namespace TraderInfoWebApi.Controllers
{
    public class TransferWindowsController : ApiController
    {
        private ITraderInfoUnitOfWork _uow = new TraderInfoUnitOfWork(new TraderInfoContext());

        // GET: api/TransferWindows
        public IQueryable<TransferWindow> GetTransferWindows()
        {
            return _uow.TransferWindows.GetAll().AsQueryable();
        }

        // GET: api/TransferWindows/5
        [ResponseType(typeof(TransferWindow))]
        public IHttpActionResult GetTransferWindow(int id)
        {
            TransferWindow transferWindow = _uow.TransferWindows.Get(id);
            if (transferWindow == null)
            {
                return NotFound();
            }

            return Ok(transferWindow);
        }

        // PUT: api/TransferWindows/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTransferWindow(int id, TransferWindow transferWindow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transferWindow.Id)
            {
                return BadRequest();
            }

            TransferWindow t = _uow.TransferWindows.Get(id);
            if (t == null)
            {
                return NotFound();
            }

            t.Period = transferWindow.Period;
            t.EndTime = transferWindow.EndTime;
            t.StartTime = transferWindow.StartTime;
            t.Price = transferWindow.Price;
            t.SmartGridId = transferWindow.SmartGridId;
            t.SumOfTrades = transferWindow.SumOfTrades;

            _uow.Complete();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TransferWindows
        [ResponseType(typeof(TransferWindow))]
        public IHttpActionResult PostTransferWindow(TransferWindow transferWindow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.TransferWindows.Add(transferWindow);
            _uow.Complete();

            return CreatedAtRoute("DefaultApi", new { id = transferWindow.Id }, transferWindow);
        }

        // DELETE: api/TransferWindows/5
        [ResponseType(typeof(TransferWindow))]
        public IHttpActionResult DeleteTransferWindow(int id)
        {
            TransferWindow transferWindow = _uow.TransferWindows.Get(id);
            if (transferWindow == null)
            {
                return NotFound();
            }

            _uow.TransferWindows.Remove(transferWindow);
            _uow.Complete();

            return Ok(transferWindow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}