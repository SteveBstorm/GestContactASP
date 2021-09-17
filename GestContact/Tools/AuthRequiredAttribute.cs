using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GestContact.Tools
{
    //Spécifie sur quoi porte l'attribut custom (dans ce cas, classe et méthodes)
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    //AuthorizeAttribute amène les méthodes à surcharger pour gérer l'autorisation
    public class AuthRequiredAttribute : AuthorizeAttribute
    {
        //Définit sur quoi se base notre autorisation 
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return SessionManager.user != null;
        }

        //Comportement en cas de rejet d'autorisation
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                Controller = "User",
                Action = "Login"
            }));
        }
    }
}