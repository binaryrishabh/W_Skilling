using Microsoft.AspNetCore.Identity;

namespace Secure_Login_App.Models {
    public class Application_User : IdentityUser {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Created_At { get; set; }
    }
}