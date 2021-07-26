using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_info_netcore5.Filter
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class UserAuthorize : AuthorizeAttribute
    {

    }
}
