USE P4_HotelReservation;
GO

DROP FUNCTION IF EXISTS fn_Nights;
GO

CREATE FUNCTION fn_Nights(@start DATE, @end DATE)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(DAY, @start, @end);
END;
GO

PRINT 'File 4 Complete';