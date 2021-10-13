using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevConferenceApp.Models
{
    public static class Repository
    {
        //lista odgovora na pozivnice
        private static List<WebinarInvite> responses= new List<WebinarInvite>();

        //listi odgovora ćemo pristupati preko javnog propertija Responses koji u biti samo sadrži našu privatnu listu
        public static IEnumerable<WebinarInvite> Responses => responses;
        public static void AddResponse(WebinarInvite response)
        {
            responses.Add(response);
        }
    }
}
