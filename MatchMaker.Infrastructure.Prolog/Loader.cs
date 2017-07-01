using System;
using System.Collections.Generic;
using MatchMaker.Core.Model;
using MatchMaker.Infrastructure.Repository;


namespace MatchMaker.Infrastructure.Prolog
{
    class Loader
    {
        TouchRepository touchRep = new Repository.TouchRepository();

        private List<string> LoadUserIdList()
        {
            List<string> userIdList = new List<string>(); 
            foreach(sp_UserSelect_Result user in touchRep.UserMasterSelect())
                userIdList.Add(user.UserId.ToString());
            return userIdList;
        }

        public Dictionary<string, string> LoadUserBookLikes()
        {
            Dictionary<string, string> UserBookLikes = new Dictionary<string, string>(); //ID1,Misterio

            foreach (string userid in LoadUserIdList())
                foreach( sp_GetUserBookLikes_Result userlike in touchRep.GetUserBookLikes(userid.ToString()))
                    UserBookLikes.Add(userid, userlike.Name);
            return UserBookLikes;
        }

        public Dictionary<string, string> LoadUserEntertainmentLikes()
        {
            Dictionary<string, string> UserEntertainmentLikes = new Dictionary<string, string>(); //ID1,Misterio

            foreach (string userid in LoadUserIdList())
                foreach (sp_GetUserEntertainmentLikes_Result userlike in touchRep.GetUserEntertainmentLikes(userid.ToString()))
                    UserEntertainmentLikes.Add(userid, userlike.Name);
            return UserEntertainmentLikes;
        }

        public Dictionary<string, string> LoadUserExpArtsLikes()
        {
            Dictionary<string, string> UserExpArtsLikes = new Dictionary<string, string>(); //ID1,Misterio

            foreach (string userid in LoadUserIdList())
                foreach (sp_GetUserExpArtsLikes_Result userlike in touchRep.GetUserExpArtsLikes(userid.ToString()))
                    UserExpArtsLikes.Add(userid, userlike.Name);
            return UserExpArtsLikes;
        }

        public Dictionary<string, string> LoadUserMusicLikes()
        {
            Dictionary<string, string> UserMusicLikes = new Dictionary<string, string>(); //ID1,Misterio

            foreach (string userid in LoadUserIdList())
                foreach (sp_GetUserMusicLikes_Result userlike in touchRep.GetUserMusicLikes(userid.ToString()))
                    UserMusicLikes.Add(userid, userlike.Name);
            return UserMusicLikes;
        }

        public Dictionary<string, string> LoadUserSportLikes()
        {
            Dictionary<string, string> UserSportLikes = new Dictionary<string, string>(); //ID1,Misterio

            foreach (string userid in LoadUserIdList())
                foreach (sp_GetUserSportLikes_Result userlike in touchRep.GetUserSportLikes(userid.ToString()))
                    UserSportLikes.Add(userid, userlike.Name);
            return UserSportLikes;
        }


    }
}
