USE P4_HotelReservation;
GO

DROP VIEW IF EXISTS vw_AvailableRooms;
DROP VIEW IF EXISTS vw_AllBookings;
GO

CREATE VIEW vw_AvailableRooms AS
SELECT room_no, price FROM Rooms WHERE status = 'Available';
GO

CREATE VIEW vw_AllBookings AS
SELECT c.name, r.room_no, b.checkin, b.checkout
FROM Bookings b
JOIN Customers c ON b.cust_id = c.id
JOIN Rooms r ON b.room_id = r.id;
GO

PRINT 'File 3 Complete';