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
    public class TradesController : ApiController
    {
        private ITraderInfoUnitOfWork _uow = new TraderInfoUnitOfWork(new TraderInfoContext());

        // GET: api/Trades
        public IQueryable<Trade> GetTrades()
        {
            return _uow.Trades.GetAll().AsQueryable();
        }

        // GET: api/Trades/5
        [ResponseType(typeof(Trade))]
        public IHttpActionResult GetTrade(int id)
        {
            Trade trade = _uow.Trades.Get(id);
            if (trade == null)
            {
                return NotFound();
            }

            return Ok(trade);
        }

        // PUT: api/Trades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrade(int id, Trade trade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trade.Id)
            {
                return BadRequest();
            }

            Trade t = _uow.Trades.Get(id);
            if (t == null)
            {
                return NotFound();
            }

            t.ConsumedEnergy = trade.ConsumedEnergy;
            t.ProducedEnergy = trade.ProducedEnergy;
            t.ProsumerId = trade.ProsumerId;
            t.SumOfEnergy = trade.SumOfEnergy;

            _uow.Complete();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Trades
        [ResponseType(typeof(Trade))]
        public IHttpActionResult PostTrade(Trade trade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.Trades.Add(trade);
            _uow.Complete();

            return CreatedAtRoute("DefaultApi", new { id = trade.Id }, trade);
        }

        // DELETE: api/Trades/5
        [ResponseType(typeof(Trade))]
        public IHttpActionResult DeleteTrade(int id)
        {
            Trade trade = _uow.Trades.Get(id);
            if (trade == null)
            {
                return NotFound();
            }

            _uow.Trades.Remove(trade);
            _uow.Complete();

            return Ok(trade);
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