using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL = Dal.Entities;
using WEB = GestContact.Models;
using GestContact.Tools;

namespace GestContact.Tools
{
    public static class Mappers
    {
        public static DAL.User ToDal(this WEB.User u)
        {
            return new DAL.User
            {
                Id = u.Id,
                Email = u.Email,
                ScreenName = u.ScreenName
            };
        }

        public static WEB.User ToWEB(this DAL.User u)
        {
            return new WEB.User
            {
                Id = u.Id,
                Email = u.Email,
                ScreenName = u.ScreenName
            };
        }

        public static DAL.Contact ToDAL(this WEB.RegisterContact c)
        {
            return new DAL.Contact
            {
                LastName = c.LastName,
                FirstName = c.FirstName,
                Telephone = c.Telephone,
                UserId = SessionManager.user.Id
            };
        }
    }
}