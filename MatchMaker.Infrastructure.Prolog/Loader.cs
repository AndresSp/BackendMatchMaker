using System;
using System.Collections.Generic;
using MatchMaker.Core.Model;
using MatchMaker.Infrastructure.Repository;


namespace MatchMaker.Infrastructure.Prolog
{
    class Loader
    {
        TouchRepository touchRep = new Repository.TouchRepository();

        private List<Guid> LoadUserIdList()
        {
            List<Guid> userIdList = new List<Guid>(); 
            foreach(sp_UserSelect_Result user in touchRep.UserMasterSelect())
                userIdList.Add(user.UserId);
            return userIdList;
        }

        public Dictionary<Guid, string> LoadUserBookLikes()
        {
            Dictionary<Guid, string> UserBookLikes = new Dictionary<Guid, string>(); //ID1,Misterio

            foreach (Guid userid in LoadUserIdList())
                foreach( sp_GetUserBookLikes_Result userlike in touchRep.GetUserBookLikes(userid.ToString()))
                    UserBookLikes.Add(userid, userlike.Name);
            return UserBookLikes;
        }

        public Dictionary<Guid, string> LoadUserEntertainmentLikes()
        {
            Dictionary<Guid, string> UserEntertainmentLikes = new Dictionary<Guid, string>(); //ID1,Misterio

            foreach (Guid userid in LoadUserIdList())
                foreach (sp_GetUserEntertainmentLikes_Result userlike in touchRep.GetUserEntertainmentLikes(userid.ToString()))
                    UserEntertainmentLikes.Add(userid, userlike.Name);
            return UserEntertainmentLikes;
        }

        public Dictionary<Guid, string> LoadUserExpArtsLikes()
        {
            Dictionary<Guid, string> UserExpArtsLikes = new Dictionary<Guid, string>(); //ID1,Misterio

            foreach (Guid userid in LoadUserIdList())
                foreach (sp_GetUserExpArtsLikes_Result userlike in touchRep.GetUserExpArtsLikes(userid.ToString()))
                    UserExpArtsLikes.Add(userid, userlike.Name);
            return UserExpArtsLikes;
        }

        public Dictionary<Guid, string> LoadUserMusicLikes()
        {
            Dictionary<Guid, string> UserMusicLikes = new Dictionary<Guid, string>(); //ID1,Misterio

            foreach (Guid userid in LoadUserIdList())
                foreach (sp_GetUserMusicLikes_Result userlike in touchRep.GetUserMusicLikes(userid.ToString()))
                    UserMusicLikes.Add(userid, userlike.Name);
            return UserMusicLikes;
        }

        public Dictionary<Guid, string> LoadUserSportLikes()
        {
            Dictionary<Guid, string> UserSportLikes = new Dictionary<Guid, string>(); //ID1,Misterio

            foreach (Guid userid in LoadUserIdList())
                foreach (sp_GetUserSportLikes_Result userlike in touchRep.GetUserSportLikes(userid.ToString()))
                    UserSportLikes.Add(userid, userlike.Name);
            return UserSportLikes;
        }


    }
}
