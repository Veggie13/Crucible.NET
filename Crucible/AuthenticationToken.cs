using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crucible
{
    class AuthenticationToken
    {
        public AuthenticationToken(string tokenString)
        {
            TokenString = tokenString;
        }

        public string TokenString { get; private set; }
    }
}
