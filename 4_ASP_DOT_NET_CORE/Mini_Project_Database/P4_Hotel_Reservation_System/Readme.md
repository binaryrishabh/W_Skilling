# Hotel Reservation Database Management System

## Domain Description
Design a database system for managing hotel operations including room booking, customer management, and billing.

## Features Implemented
- Master data management for core entities
- Transaction handling for reservations and payments
- Relationship mapping using primary and foreign keys
- Data validation using constraints (NOT NULL, CHECK, UNIQUE)
- Querying using joins, subqueries, and aggregation
- Views for reporting and abstraction
- Indexes for performance optimization
- Triggers for automation and audit logging
- Access control using GRANT and REVOKE
- Transaction handling using COMMIT and ROLLBACK

## Database Design Approach
- Normalization applied up to 3NF
- ER Diagram created using Draw.io
- Primary key and foreign key relationships defined

## How to Execute Scripts
1. Open SQL Server Management Studio (SSMS)
2. Connect to your SQL Server instance
3. Execute scripts in the following order:
   - SQL/ddl_scripts.sql
   - SQL/dml_scripts.sql
   - SQL/views.sql
   - SQL/functions.sql
   - SQL/triggers.sql
   - SQL/queries.sql
4. Verify outputs in the /Output folder

## Sample Queries & Outputs

### Query 1: View available rooms
```sql
SELECT room_number, room_type, price_per_night 
FROM Rooms 
WHERE status = 'Available';