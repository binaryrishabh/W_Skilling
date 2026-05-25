USE P4_HotelReservation;
GO

DELETE FROM Bookings;
DELETE FROM Rooms;
DELETE FROM Customers;
GO

INSERT INTO Customers VALUES ('Raj', '9876543210');
INSERT INTO Customers VALUES ('Priya', '9876543211');
INSERT INTO Customers VALUES ('Amit', '9876543212');
INSERT INTO Customers VALUES ('Neha', '9876543213');

INSERT INTO Rooms VALUES (101, 5000, 'Available');
INSERT INTO Rooms VALUES (102, 5000, 'Available');
INSERT INTO Rooms VALUES (201, 3000, 'Available');
INSERT INTO Rooms VALUES (202, 3000, 'Available');
INSERT INTO Rooms VALUES (301, 8000, 'Available');

-- Room IDs will be: 101,102,103,104,105 (in that order)
-- So room_no 101 = id 101, room_no 201 = id 103, room_no 202 = id 104

INSERT INTO Bookings (cust_id, room_id, checkin, checkout) VALUES (1, 101, '2026-06-01', '2026-06-03');
INSERT INTO Bookings (cust_id, room_id, checkin, checkout) VALUES (2, 103, '2026-06-05', '2026-06-07');

PRINT 'File 2 Complete';