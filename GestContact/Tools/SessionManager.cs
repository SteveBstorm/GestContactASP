using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestContact.Models;

namespace GestContact.Tools
{
    public class SessionManager
    {
        public static User user
        {
            get { return (User)HttpContext.Current.Session["user"]; }
            set { HttpContext.Current.Session["user"] = value; }
        }
    }
}