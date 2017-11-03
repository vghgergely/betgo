using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Betgo.Models.Extensions
{
    public static class IdentityExtensions
    {
        public static double GetUserMoney(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("Money");
            return (claim != null) ? Double.Parse(claim.Value) : 0;
        }
    }
}