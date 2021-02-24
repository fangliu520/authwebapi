using authwebapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authwebapi.Utility
{
    public interface ICustomJWTService
    {
        string GetToken(string UserName, string password, User user);
    }
}
