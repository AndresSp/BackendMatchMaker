using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MatchMaker.Core.Interfaces.Repository;
using MatchMaker.Core.Model;
using System.Data.Entity.Core;

namespace MatchMaker.Controllers
{
    public class UserDataController : ApiController
    {
        private readonly ITouchRepository _db;

        public UserDataController(ITouchRepository db)
        {
            _db = db;
        }

        [Route("wsregisteruser")]
        [HttpPost]
        public HttpResponseMessage RegisterUserInApp(string pEmail, string pPassword, string pFirstName, string pLastName)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                sp_UserRegister_Result content = _db.RegisterUser(pEmail, pPassword, pFirstName, pLastName);
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

        [Route("wsgetuserprofile")]
        [HttpPost]
        public HttpResponseMessage GetUserProfile(string pUserId)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                sp_UserSelectById_Result content = _db.GetUserProfile(pUserId);
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

        [Route("wsgetusermatch")]
        [HttpPost]
        public HttpResponseMessage GetUserMatch(string pUserId)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                List<sp_GetUserMatchs_Result> content = _db.GetUserMatch(pUserId);
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

        [Route("wsdeleteuser")]
        [HttpPost]
        public HttpResponseMessage DeleteUserInApp(string pUserId)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                _db.DeleteUser(pUserId);
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

        [Route("wssetuserbooklike")]
        [HttpPost]
        public HttpResponseMessage SetUserBookLike(string pUserId, int pGenreId)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                sp_User_BooksRegister_Result content =  _db.SetUserLikesBooks(pUserId, pGenreId);
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
