using authwebapi.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace authwebapi.Utility
{
    public static class CommonExtend
    {
        /// <summary>
        /// 基于HttpContext,当前鉴权方式解析，获取用户信息
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static User GetCurrentUserInfo(this HttpContext httpContext)
        {
            IEnumerable<Claim> claimlist = httpContext.AuthenticateAsync().Result.Principal.Claims;
            return new User()
            {
                id = int.Parse(claimlist.FirstOrDefault(u => u.Type == "id").Value),
                username = claimlist.FirstOrDefault(u => u.Type == "username").Value ?? "匿名"
            };
        }
    }
}
