using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prolog;

namespace MatchMaker.Infrastructure.Prolog
{
    class PrologLogic
    {
        Loader loader = new Loader();
        PrologEngine prolog = new PrologEngine();

        //public void 

        private void LoadLikesToProlog()
        {
            foreach (KeyValuePair<string, string> userlike in loader.LoadUserBookLikes())
                prolog.ConsultFromString(string.Format("likeBooks({0},{1}).", userlike.Key, userlike.Value));

            foreach (KeyValuePair<string, string> userlike in loader.LoadUserEntertainmentLikes())
                prolog.ConsultFromString(string.Format("likeEntertainment({0},{1}).", userlike.Key, userlike.Value));

            foreach (KeyValuePair<string, string> userlike in loader.LoadUserExpArtsLikes())
                prolog.ConsultFromString(string.Format("likeExpArts({0},{1}).", userlike.Key, userlike.Value));

            foreach (KeyValuePair<string, string> userlike in loader.LoadUserMusicLikes())
                prolog.ConsultFromString(string.Format("likeMusic({0},{1}).", userlike.Key, userlike.Value));

            foreach (KeyValuePair<string, string> userlike in loader.LoadUserSportLikes())
                prolog.ConsultFromString(string.Format("likeSport({0},{1}).", userlike.Key, userlike.Value));
        }




    }
}
