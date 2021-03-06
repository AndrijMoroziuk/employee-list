﻿using AspNet.Identity.MongoDB;
using EmployeeList.Domain.Entities.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeList.Web.App_Start
{
    public class EnsureAuthIndexes
    {
        public static void Exist()
        {
            var context = ApplicationIdentityContext.Create();
            IndexChecks.EnsureUniqueIndexOnUserName(context.ApplicationUsers);
            IndexChecks.EnsureUniqueIndexOnRoleName(context.IdentityRoles);
        }
    }
}