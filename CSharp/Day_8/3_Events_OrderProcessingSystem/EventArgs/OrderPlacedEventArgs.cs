namespace _3_Events_OrderProcessingSystem.EventArgs {
    public class OrderPlacedEventArgs : System.EventArgs {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderPlacedEventArgs(int orderId, string customerName, decimal totalAmount) {
            OrderId = orderId;
            CustomerName = customerName;
            TotalAmount = totalAmount;
            OrderDate = DateTime.Now;
        }

        public override string ToString() {
            return $"Order #{OrderId} | Customer: {CustomerName} | Amount: ₹{TotalAmount:N2} | Date: {OrderDate:dd-MM-yyyy HH:mm:ss}";
        }
    }
}