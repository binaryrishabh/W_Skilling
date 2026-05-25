USE P4_HotelReservation;
GO

DROP TRIGGER IF EXISTS trg_UpdateRoom;
DROP TRIGGER IF EXISTS trg_CalcTotal;
GO

CREATE TRIGGER trg_UpdateRoom
ON Bookings
AFTER INSERT
AS
BEGIN
    UPDATE Rooms SET status = 'Booked'
    WHERE id IN (SELECT room_id FROM inserted);
END;
GO

CREATE TRIGGER trg_CalcTotal
ON Bookings
INSTEAD OF INSERT
AS
BEGIN
    INSERT INTO Bookings (cust_id, room_id, checkin, checkout, total)
    SELECT i.cust_id, i.room_id, i.checkin, i.checkout,
           DATEDIFF(DAY, i.checkin, i.checkout) * r.price
    FROM inserted i
    JOIN Rooms r ON i.room_id = r.id;
END;
GO

PRINT 'File 5 Complete';