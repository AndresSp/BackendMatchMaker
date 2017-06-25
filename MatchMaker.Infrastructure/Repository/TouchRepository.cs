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
    }
}
