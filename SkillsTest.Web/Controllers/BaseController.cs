using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SkillsTest.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected Guid? GetUserId()
        {
            var claimsIdentity = User != null ? User.Identity as ClaimsIdentity : null;

            if (claimsIdentity != null)
            {
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                if(claim != null)
                {
                    return Guid.Parse(claim.Value);
                }
            }

            return null;
        }
    }
}