namespace Secure_Login_App.Models {
    public class User_Details {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Role { get; set; }
        public DateTime Created_At { get; set; }
    }
}