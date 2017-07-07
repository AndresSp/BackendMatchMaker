using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMaker.Core.Model
{
    public class ResultResponseModel
    {
        public Object Result { get; set; }
        public Object Error { get; set; }
    }

    public class UserLikesModel
    {
        public List<sp_GetUserBookLikes_Result> Books { get; set; }
        public List<sp_GetUserMusicLikes_Result> Music { get; set; }
        public List<sp_GetUserSportLikes_Result> Sports { get; set; }
        public List<sp_GetUserEntertainmentLikes_Result> Entertainment { get; set; }
        public List<sp_GetUserExpArtsLikes_Result> ExpArt { get; set; }
    }

    public class ImageModel
    {
        public string pUserId { get; set; }
        public string pPhotoEncoded { get; set; }
        public string pFileName { get; set; }
    }
}
