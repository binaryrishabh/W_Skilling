using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace _4_Real_Time_Order_Notification_System.Services {
    public class SMSService {
        public void SendSMS(Order order) {
            Console.WriteLine($"[SMSService]  📱 SMS sent to +91-XXXXXXXXXX");
            Console.WriteLine($"              Message: Order #{order.OrderId} placed successfully for ${order.Amount:F2}");
        }
    }
}