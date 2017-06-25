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
        #endregion
    }
}
