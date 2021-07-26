using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_info_netcore5.Models
{
    //Creación de atributos para la tabla userlogins
    public class UserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }
    }
}
