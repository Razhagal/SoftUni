using SIS.MvcFramework.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.MvcFramework.Attributes.Security
{
    public class AuthorizeAttribute : Attribute
    {
        private const string Authorized = "authorized";
        private const string Anonymous = "anonymous";

        private readonly string authority;

        public AuthorizeAttribute(string authority = Authorized)
        {
            this.authority = authority;
        }

        private bool IsLoggedIn(IdentityUser user)
        {
            return user != null;
        }

        public bool IsInAuthority(IdentityUser user)
        {
            if (!this.IsLoggedIn(user))
            {
                return this.authority == Anonymous;
            }

            return this.authority == Authorized || user.Roles.Contains(this.authority.ToLower());
        }
    }
}
