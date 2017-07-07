using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MatchMaker.Core.Model;
using MatchMaker.Infrastructure.Repository;
using System.Data.Entity.Core;
using MatchMaker.Core.Interfaces.Repository;

namespace MatchMaker.Controllers
{
    public class BlobServiceController : ApiController
    {
        private readonly ITouchRepository _db;

        public BlobServiceController(ITouchRepository db)
        {
            _db = db;
        }

        [Route("wsuploadimage")]
        [HttpPost]
        public HttpResponseMessage UploadImage(ImageModel content)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                string url = new BlobServices().UploadPhoto(content.pPhotoEncoded, content.pFileName);

                _db.UpdateUserPhoto(content.pUserId, url);

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
