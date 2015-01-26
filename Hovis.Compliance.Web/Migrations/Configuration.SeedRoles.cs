﻿using Hovis.Compliance.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;

namespace Hovis.Compliance.Web.Migrations
{
    internal partial class Configuration
    {
        private static void SeedRoles(ApplicationDbContext context)
        {
            var rolesToCreate = new[]
            {
                "Admin"
                //others can be added here
            };

            //iterate over the array of roles to create
            foreach (var roleToCreate in rolesToCreate)
                context.Roles.AddOrUpdate(role => role.Name, new IdentityRole(roleToCreate));
        }
    }
}