USE P4_HotelReservation;
GO

PRINT '--- INNER JOIN ---';
SELECT c.name, r.room_no FROM Customers c
INNER JOIN Bookings b ON c.id = b.cust_id
INNER JOIN Rooms r ON b.room_id = r.id;

PRINT '--- LEFT JOIN ---';
SELECT r.room_no, b.id FROM Rooms r
LEFT JOIN Bookings b ON r.id = b.room_id;

PRINT '--- SUBQUERY ---';
SELECT name FROM Customers
WHERE id IN (SELECT cust_id FROM Bookings);

PRINT '--- GROUP BY ---';
SELECT r.room_no, COUNT(b.id) as total
FROM Rooms r
LEFT JOIN Bookings b ON r.id = b.room_id
GROUP BY r.room_no;