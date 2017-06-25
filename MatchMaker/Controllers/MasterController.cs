using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;
using System.Data;
using MatchMaker.Core.Interfaces.Repository;
using MatchMaker.Core.Model;
using System.Data.Entity.Core;

namespace MatchMaker.Controllers
{
    public class MasterController : ApiController
    {
        private readonly ITouchRepository _db;

        public MasterController(ITouchRepository db)
        {
            _db = db;
        }

        [Route("wsgetbooksmaster")]
        [HttpGet]
        public HttpResponseMessage GetBooksGenre()
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                List<sp_BooksSelect_Result> content = _db.BooksMasterSelect(0);
                result.Result = content;
                result.Error = new { Error = 200, ErrorMessage = "Ok" };
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (ArgumentNullException)
            {
                ResultResponseModel objresult = new ResultResponseModel();
                objresult.Error = new { Error = 400, ErrorMessage = HttpStatusCode.BadRequest };
                return Request.CreateResponse(HttpStatusCode.BadRequest, objresult);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            catch (EntityCommandExecutionException e)
            {
                ResultResponseModel objresult = new ResultResponseModel();
                objresult.Error = new { Error = 5004, ErrorMessage = "Device o  Customer No Encontrados" };
                return Request.CreateResponse(HttpStatusCode.BadRequest, objresult);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                ResultResponseModel objresult = new ResultResponseModel();
                objresult.Error = new { Error = 406, ErrorMessage = e.Message };
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, objresult);
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);
            }
        }
    }
}
