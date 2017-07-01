using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchMaker.Core.Model;

namespace MatchMaker.Core.Interfaces.Repository
{
    public interface ITouchRepository
    {
        #region Master Select
        List<sp_BooksSelect_Result> BooksMasterSelect(int pGenreId);
        List<sp_EntertainmentSelect_Result> EntertainmentMasterSelect(int pGenreId);
        List<sp_ExpArtsSelect_Result> ExpArtsMasterSelect(int pGenreId);
        List<sp_MusicSelect_Result> MusicMasterSelect(int pGenreId);
        List<sp_SportsSelect_Result> SportsMasterSelect(int pGenreId);
        List<sp_FacultySelect_Result> FacultyMasterSelect(int pFacultyId);
        List<sp_UserSelect_Result> UserMasterSelect();
        #endregion

        #region User Data Management
        List<sp_GetUserMatchs_Result> GetUserMatch(string pUserId);
        sp_UserSelectById_Result GetUserProfile(string pUserId);
        sp_UserRegister_Result RegisterUser(string pEmail, string pPassword, string pFirstName, string pLastName);
        void DeleteUser(string pUserId);
        sp_User_BooksRegister_Result SetUserLikesBooks(string pUserId, int pGenreId);
        sp_User_EntertainmentRegister_Result SetUserLikesEntertaiment(string pUserId, int pGenreId);
        sp_User_ExpArtsRegister_Result SetUserLikesExpArts(string pUserId, int pGenreId);
        sp_User_MusicRegister_Result SetUserLikesMusic(string pUserId, int pGenreId);
        sp_User_SportRegister_Result SetUserLikesSport(string pUserId, int pGenreId);
        //sp for comparing passwords

        
        #endregion
    }
}
