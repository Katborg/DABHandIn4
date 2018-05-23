using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SmartGrid;


namespace SmartGridWepApi.Controllers
{

    public class SmartGridInfoController : ApiController
	{
        private readonly SmartGridRepository _smartGrids = new SmartGridRepository("F18I4DABH4Gr13", "SmartGrids");

        // GET: api/People
        public IQueryable<DAB4.Models.SmartGrid> GetPersons()
        {
            var persons = from s in _smartGrids.GetAll().AsQueryable()
                          select new DAB4.Models.SmartGrid()
                          {
                              Id = s.Id,
                              NumberOfPrivateHomes = s.NumberOfPrivateHomes,
                              NumberOfCompanies = s.NumberOfCompanies,
                              EnergyBalance = s.EnergyBalance,
                              SmartMeters = s.SmartMeters,
                              WireInfo = s.WireInfo,
                              EnergyStorage = s.EnergyStorage
                          };

            return persons;
        }

        // GET: api/People/5
        [ResponseType(typeof(DAB4.Models.SmartGrid))]
        public IHttpActionResult GetPerson(int id)
        {
            DAB4.Models.SmartGrid s = _smartGrids.Get(id);

            if (s == null)
            {
                return NotFound();
            }

            return Ok(s);
        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson(int id, DAB4.Models.SmartGrid grid)
        {
            DAB4.Models.SmartGrid newPerson = _smartGrids.ReplaceSmartGridDocument(id, grid);

            if (newPerson == null)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/People
        [ResponseType(typeof(DAB4.Models.SmartGrid))]
        public IHttpActionResult PostPerson(DAB4.Models.SmartGrid grid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _smartGrids.Add(grid);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return CreatedAtRoute("DefaultApi", new { id = grid.Id }, grid);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeletePerson(int id)
        {
            DAB4.Models.SmartGrid p = _smartGrids.Get(id);
            if (p != null)
            {
                _smartGrids.Remove(p);
                return StatusCode(HttpStatusCode.NoContent);
            }
            return NotFound();
        }
    }
}