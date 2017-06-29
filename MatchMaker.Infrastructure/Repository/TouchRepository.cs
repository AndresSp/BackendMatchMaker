using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchMaker.Core.Interfaces.Repository;
using MatchMaker.Core.Model;
using MatchMaker.Infrastructure.Data;

namespace MatchMaker.Infrastructure.Repository
{
    public class TouchRepository : ITouchRepository
    {
        #region Maestros
        public List<sp_BooksSelect_Result> BooksMasterSelect(int pGenreId)
        {
            using (touchdbEntities context = new touchdbEntities())
            {
                var pBookMaster = context.sp_BooksSelect(pGenreId).ToList();
                return pBookMaster;
            }
        }

        public List<sp_EntertainmentSelect_Result> EntertainmentMasterSelect(int pGenreId)
        {
            using (touchdbEntities context = new touchdbEntities())
            {
                var pEnterMaster = context.sp_EntertainmentSelect(pGenreId).ToList();
                return pEnterMaster;
            }
        }

        public List<sp_ExpArtsSelect_Result> ExpArtsMasterSelect(int pGenreId)
        {
            using (touchdbEntities context = new touchdbEntities())
            {
                var pArtsMaster = context.sp_ExpArtsSelect(pGenreId).ToList();
                return pArtsMaster;
            }
        }

        public List<sp_MusicSelect_Result> MusicMasterSelect(int pGenreId)
        {
            using (touchdbEntities context = new touchdbEntities())
            {
                var pMusicMaster = context.sp_MusicSelect(pGenreId).ToList();
                return pMusicMaster;
            }
        }

        public List<sp_SportsSelect_Result> SportsMasterSelect(int pGenreId)
        {
            using (touchdbEntities context = new touchdbEntities())
            {
                var pSportMaster = context.sp_SportsSelect(pGenreId).ToList();
                return pSportMaster;
            }
        }

        public List<sp_FacultySelect_Result> FacultyMasterSelect(int pFacultyId)
        {
            using (touchdbEntities context = new touchdbEntities())
            {
                var pFacultyMaster = context.sp_FacultySelect(pFacultyId).ToList();
                return pFacultyMaster;
            }
        }

        public List<sp_UserSelect_Result> UserMasterSelect()
        {
            using (touchdbEntities context = new touchdbEntities())
            {
                var pRegisteredUsers = context.sp_UserSelect().ToList();
                return pRegisteredUsers;
            }
        }
        #endregion

        #region User Data Management
        public List<sp_GetUserMatchs_Result> GetUserMatch(string pUserId)
        {
            using (touchdbEntities context = new touchdbEntities())
            {
                var pUserMatch = context.sp_GetUserMatchs(Guid.Parse(pUserId)).ToList();
                return pUserMatch;
            }
        }

        public sp_UserSelectById_Result GetUserProfile(string pUserId)
        {
            using (touchdbEntities context = new touchdbEntities())
            {
                var pUserProfile = context.sp_UserSelectById(Guid.Parse(pUserId)).FirstOrDefault();
                return pUserProfile;
            }
        }

        public sp_UserRegister_Result RegisterUser(string pEmail, string pPassword, string pFirstName, string pLastName)
        {
            using (touchdbEntities context = new touchdbEntities())
            {
                var pRegisteredUser = context.sp_UserRegister(pEmail, pPassword, pFirstName, pLastName).FirstOrDefault();
                return pRegisteredUser;
            }
        }

        public void DeleteUser(string pUserId)
        {
            using (touchdbEntities context = new touchdbEntities())
            {
                context.sp_UserDelete(Guid.Parse(pUserId));
            }
        }

        public sp_User_BooksRegister_Result SetUserLikesBooks(string pUserId, int pGenreId)
        {
            using (touchdbEntities context = new touchdbEntities())
            {
                var pBookRegistered = context.sp_User_BooksRegister(Guid.Parse(pUserId), pGenreId).FirstOrDefault();
                return pBookRegistered;
            }
        }
        #endregion

        #region User Likes Management (IA)

        #endregion
    }
}
