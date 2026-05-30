using System.Net;

namespace _2_MvcModelBinding.Models {
    public class User {
        public string FirstName { get; set; }   // Indian first names only
        public string LastName { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }    // Nested model
    }
}