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
        public HttpResponseMessage RegisterUserInApp(string pEmail, string pPassword, string pFirstName, string pLastName, string pPhoneNumber)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                sp_UserRegister_Result content = _db.RegisterUser(pEmail, pPassword, pFirstName, pLastName, pPhoneNumber);
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

        [Route("wslogin")]
        [HttpPost]
        public HttpResponseMessage Login(string pEmail, string pPassword)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                sp_UserSelectByEmail_Result content = _db.GetUserByEmail(pEmail);                

                if(content == null)
                {
                    result.Result = "Email Incorrecto";
                    result.Error = new { Error = 201, ErrorMessage = "Verificar Email" };
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }

                sp_UserSelectPassword_Result password = _db.GetUserPassword(content.UserId);

                if (pPassword == password.Password)
                {
                    result.Result = content;
                    result.Error = new { Error = 200, ErrorMessage = "Ok" };
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    result.Result = "Contraseña Incorrecta";
                    result.Error = new { Error = 201, ErrorMessage = "Verificar Contraseña" };
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                              
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
                objresult.Error = new { Error = 5004, ErrorMessage = "Usuario No Encontrado" };
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

        [Route("wsupdateuserprofile")]
        [HttpPost]
        public HttpResponseMessage UpdateUserProfile(string pUserId, string pFirstName, string pLastName, string pPhoneNumber, string pNacDate, char pGender, char pGenderPref, string pEmail, int pFaculty, string pImageUrl)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                sp_UserUpdateProfile_Result content = _db.UpdateUserProfile(pUserId, pFirstName, pLastName, pPhoneNumber, DateTime.Parse(pNacDate), pGender, pGenderPref, pEmail, pFaculty, pImageUrl);
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
                _db.FindAllMatch(pUserId);
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

        [Route("wssetusermusiclike")]
        [HttpPost]
        public HttpResponseMessage SetUserMusicLike(string pUserId, int pGenreId)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                sp_User_MusicRegister_Result content = _db.SetUserLikesMusic(pUserId, pGenreId);
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

        [Route("wssetusersportlike")]
        [HttpPost]
        public HttpResponseMessage SetUserSportLike(string pUserId, int pGenreId)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                sp_User_SportRegister_Result content = _db.SetUserLikesSport(pUserId, pGenreId);
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

        [Route("wssetuserartslike")]
        [HttpPost]
        public HttpResponseMessage SetUserExpArtLike(string pUserId, int pGenreId)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                sp_User_ExpArtsRegister_Result content = _db.SetUserLikesExpArts(pUserId, pGenreId);
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

        [Route("wssetuserentertainmentlike")]
        [HttpPost]
        public HttpResponseMessage SetUserEntertainmentLike(string pUserId, int pGenreId)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                sp_User_EntertainmentRegister_Result content = _db.SetUserLikesEntertaiment(pUserId, pGenreId);
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

        [Route("wssetusertechlike")]
        [HttpPost]
        public HttpResponseMessage SetUserTechLike(string pUserId, int pWeigth)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                _db.SetUserWeightTech(pUserId, pWeigth);
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

        [Route("wssetusertravellike")]
        [HttpPost]
        public HttpResponseMessage SetUserTravelLike(string pUserId, int pWeigth)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                _db.SetUserWeightTravel(pUserId, pWeigth);
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

        [Route("wsgetuserlikes")]
        [HttpPost]
        public HttpResponseMessage GetUserLikes(string pUserId)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                UserLikesModel content = new UserLikesModel();
                content.Books = _db.GetUserBookLikes(pUserId);
                content.Music = _db.GetUserMusicLikes(pUserId);
                content.Sports = _db.GetUserSportLikes(pUserId);
                content.Entertainment = _db.GetUserEntertainmentLikes(pUserId);
                content.ExpArt = _db.GetUserExpArtsLikes(pUserId);

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

        [Route("wsdeletebook")]
        [HttpPost]
        public HttpResponseMessage DeleteBookInApp(string pUserId, int pGenreId)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                _db.DeleteUserBook(pUserId, pGenreId);
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

        [Route("wsdeletemusic")]
        [HttpPost]
        public HttpResponseMessage DeleteMusicInApp(string pUserId, int pGenreId)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                _db.DeleteUserMusic(pUserId, pGenreId);
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

        [Route("wsdeletesport")]
        [HttpPost]
        public HttpResponseMessage DeleteSportInApp(string pUserId, int pGenreId)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                _db.DeleteUserSport(pUserId, pGenreId);
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

        [Route("wsdeleteart")]
        [HttpPost]
        public HttpResponseMessage DeleteArtInApp(string pUserId, int pGenreId)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                _db.DeleteUserArt(pUserId, pGenreId);
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

        [Route("wsdeleteentertainment")]
        [HttpPost]
        public HttpResponseMessage DeleteEntertainmentInApp(string pUserId, int pGenreId)
        {
            try
            {
                ResultResponseModel result = new ResultResponseModel();
                _db.DeleteUserEntertainment(pUserId, pGenreId);
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
