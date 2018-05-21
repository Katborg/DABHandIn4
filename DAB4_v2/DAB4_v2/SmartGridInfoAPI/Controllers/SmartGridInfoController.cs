using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGrid;

namespace SmartGridInfoAPI.Controllers
{
    public class SmartGridInfoController : ApiController
    {
	    public class SmarGridInfoController : ApiController
	    {
		    private readonly SmartGridRepository _smartGridRepository = new SmartGridRepository();

		    // GET api/values
		    [System.Web.Http.HttpGet]
		    public IHttpActionResult Get(int id)
		    {
			    var product = _smartGridRepository.Get(id);

			    if (product == null)
			    {
				    return NotFound();
			    }

			    return Ok(product);
		    }

		    [System.Web.Http.HttpPost]
		    public IHttpActionResult Post(int id, DAB4.Models.SmartGrid smartGrid)
		    {


			    if (_smartGridRepository.Get(id) != null)
			    {
				    return StatusCode(HttpStatusCode.NotAcceptable);
			    }


			    _smartGridRepository.Add(smartGrid);
			    return StatusCode(HttpStatusCode.Accepted);
		    }
	    }

	}
}
