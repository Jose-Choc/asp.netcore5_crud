using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_info_netcore5.Models;

namespace test_info_netcore5.Data
{
    
    //tabla Roles
    public class ApplicationRole : IdentityRole<int>
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }
    //tabla userroles
    public class ApplicationRoleClaim : IdentityRoleClaim<int>
    {
        public virtual ApplicationRole Role { get; set; }
    }
    //Tabla para el usuario
    public class ApplicationUser : IdentityUser<int>
    {
        //public override int Id { get; set; }
        public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
        public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
        public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        //campo que se verá en la tabla Usuarios como UsuariosID o algo asi

        public virtual ICollection<Users> Usuarios { get; set; }
    }

    //tabla userroles
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
    //UserClaims para decirme que el id estan 
    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
        public virtual ApplicationUser User { get; set; }
    }

    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
        public virtual ApplicationUser User { get; set; }
    }

    public class ApplicationUserToken : IdentityUserToken<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
