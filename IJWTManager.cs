using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncuestasApi
{
    interface IJWTManager
    {
        public Task<Tokens> Authenticate(UserSession user);
    }
}
