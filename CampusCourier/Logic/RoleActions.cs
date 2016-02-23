using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CampusCourier.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Configuration;
using System.Data.SqlClient;

namespace CampusCourier.Logic
{
    internal class RoleActions
    {
        internal void AddUserAndRole()
        {
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Then, you create the "canEdit" role if it doesn't already exist.
            if (!roleMgr.RoleExists("courier"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "courier" });
            }

            // Then, you create the "canEdit" role if it doesn't already exist.
            if (!roleMgr.RoleExists("restaurantManager"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "restaurantManager" });
            }

            // Then, you create the "canEdit" role if it doesn't already exist.
            if (!roleMgr.RoleExists("admin"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "admin" });
            }

            // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            // object. Note that you can create new objects and use them as parameters in
            // a single line of code, rather than using multiple lines of code, as you did
            // for the RoleManager object.
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                UserName = "courier@campuscourier.com",
                Email = "courier@campuscourier.com"
            };
            IdUserResult = userMgr.Create(appUser, "Cc123!");

            // If the new "canEdit" user was successfully created, 
            // add the "canEdit" user to the "canEdit" role. 
            if (!userMgr.IsInRole(userMgr.FindByEmail("courier@campuscourier.com").Id, "courier"))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("courier@campuscourier.com").Id, "courier");
            }

            appUser = new ApplicationUser
            {
                UserName = "courierPrivate@campuscourier.com",
                Email = "courierPrivate@campuscourier.com"
            };
            IdUserResult = userMgr.Create(appUser, "Cc123!");

            // If the new "canEdit" user was successfully created, 
            // add the "canEdit" user to the "canEdit" role. 
            if (!userMgr.IsInRole(userMgr.FindByEmail("courierPrivate@campuscourier.com").Id, "courier"))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("courierPrivate@campuscourier.com").Id, "courier");
            }

            appUser = new ApplicationUser
            {
                UserName = "restManager@campuscourier.com",
                Email = "restManager@campuscourier.com"
            };
            IdUserResult = userMgr.Create(appUser, "Cc123!");

            // If the new "canEdit" user was successfully created, 
            // add the "canEdit" user to the "canEdit" role. 
            if (!userMgr.IsInRole(userMgr.FindByEmail("restManager@campuscourier.com").Id, "restaurantManager"))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("restManager@campuscourier.com").Id, "restaurantManager");
            }

            appUser = new ApplicationUser
            {
                UserName = "admin@campuscourier.com",
                Email = "admin@campuscourier.com"
            };
            IdUserResult = userMgr.Create(appUser, "Cc123!");

            // If the new "canEdit" user was successfully created, 
            // add the "canEdit" user to the "canEdit" role. 
            if (!userMgr.IsInRole(userMgr.FindByEmail("admin@campuscourier.com").Id, "admin"))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("admin@campuscourier.com").Id, "admin");
            }
        }
    }
}