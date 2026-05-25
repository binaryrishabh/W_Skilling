USE P4_HotelReservation;
GO

DROP TABLE IF EXISTS Bookings;
DROP TABLE IF EXISTS Rooms;
DROP TABLE IF EXISTS Customers;
GO

CREATE TABLE Customers (
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(30) NOT NULL,
    phone VARCHAR(10) NOT NULL UNIQUE
);

CREATE TABLE Rooms (
    id INT PRIMARY KEY IDENTITY(101,1),
    room_no INT UNIQUE NOT NULL,
    price INT NOT NULL,
    status VARCHAR(10) DEFAULT 'Available'
);

CREATE TABLE Bookings (
    id INT PRIMARY KEY IDENTITY(1,1),
    cust_id INT FOREIGN KEY REFERENCES Customers(id),
    room_id INT FOREIGN KEY REFERENCES Rooms(id),
    checkin DATE NOT NULL,
    checkout DATE NOT NULL,
    total INT
);

CREATE INDEX idx_dates ON Bookings(checkin, checkout);

PRINT 'File 1 Complete';