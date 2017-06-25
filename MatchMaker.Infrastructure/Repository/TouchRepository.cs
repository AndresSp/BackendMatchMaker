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

            //using (CasadeLasBateriasDataContainer context = new CasadeLasBateriasDataContainer())
            //{
            //    var pBrandMaster = context.sp_SelectBrandMaster(pId, pIdExt, pIdUser, pSort, pStatus, pAppC, pAppI).ToList();
            //    return pBrandMaster;
            //}
        }
    }
}
