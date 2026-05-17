namespace _1_E_Commerce_Order_Management_System {
    // Customer Class
    public class Customer {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public Customer(int id, string name) {
            CustomerId = id;
            Name = name;
        }
    }
}