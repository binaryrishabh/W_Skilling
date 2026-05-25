USE P4_HotelReservation;
GO

PRINT '--- COMMIT Example ---';
BEGIN TRANSACTION;
INSERT INTO Bookings (cust_id, room_id, checkin, checkout) VALUES (3, 104, '2026-06-10', '2026-06-12');
COMMIT;
PRINT 'Insert committed';

PRINT '--- ROLLBACK Example ---';
BEGIN TRANSACTION;
DELETE FROM Bookings WHERE id = 3;
ROLLBACK;
PRINT 'Delete rolled back';

PRINT '--- DCL Example ---';
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'hotel_user')
BEGIN
    CREATE USER hotel_user WITHOUT LOGIN;
    PRINT 'User created';
END
ELSE
BEGIN
    PRINT 'User already exists';
END

GRANT SELECT ON vw_AvailableRooms TO hotel_user;
PRINT 'Permission granted';