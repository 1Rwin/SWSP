using SWSPapp.Models;
using System.Web;

namespace SWSPapp.Services
{
    public class SessionPersister
    {
        static string user = "user";

        public static UserModel User
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;
                var sessionVar = HttpContext.Current.Session[user];
                if (sessionVar != null)
                    return sessionVar as UserModel;
                return null;
            }
            set
            {
                HttpContext.Current.Session.Timeout = 10;
                HttpContext.Current.Session[user] = value;
            }
        }
    }
}