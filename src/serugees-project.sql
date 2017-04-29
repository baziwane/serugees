-- Create a new database called 'SerugeesDb'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
  SELECT name
   FROM sys.databases
   WHERE name = N'SerugeesDb'
)
CREATE DATABASE SerugeesDb
GO

-- Create a new table called 'Members' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Members', 'U') IS NOT NULL
DROP TABLE dbo.Members
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Members
(
    MembersId INT NOT NULL PRIMARY KEY, -- primary key column
    FirstName [NVARCHAR](50) NOT NULL,
    LastName [NVARCHAR](50) NOT NULL,
    PhoneNumber [NVARCHAR](50) NOT NULL,
    JoinDate DATETIME NOT NULL
   -- specify more columns here
);
GO

-- Create a new table called 'Loans' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Loans', 'U') IS NOT NULL
DROP TABLE dbo.Loans
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Loans
(
    LoansId INT NOT NULL PRIMARY KEY, -- primary key column
    Amount INT NOT NULL,
    DurationInMonths INT NOT NULL,
    DateRequested DATETIME DEFAULT GETDATE(),
    MembersId INT FOREIGN KEY REFERENCES Members (MembersId)       
);
GO

-- Create a new table called 'Payments' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Payments', 'U') IS NOT NULL
DROP TABLE dbo.Payments
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Payments
(
    PaymentsId INT NOT NULL PRIMARY KEY, -- primary key column
    LoanPrincipal INT NOT NULL,
    AmountPaid INT NOT NULL,
    DepositDate DATETIME DEFAULT GETDATE(),
    NextInstallmentDueDate DATETIME DEFAULT (GETDATE()+30),
    MinimumPaymentDue INT NOT NULL,
    LoansId INT FOREIGN KEY REFERENCES Loans (LoansId),
);
GO

ALTER TABLE dbo.Loans DROP CONSTRAINT FK__Loans__MembersId__3A81B327;
ALTER TABLE dbo.Loans DROP COLUMN MembersId;

ALTER TABLE dbo.Members DROP CONSTRAINT PK__Members__5457C0ABA459DB69;
ALTER TABLE dbo.Members DROP COLUMN MembersId;

ALTER TABLE dbo.Members ADD MembersId int IDENTITY(1, 1) NOT NULL;
ALTER TABLE dbo.Members ADD CONSTRAINT PK_Members PRIMARY KEY CLUSTERED (MembersId);
ALTER TABLE dbo.Loans ADD MembersId INT FOREIGN KEY REFERENCES Members (MembersId)
GO

-- Insert rows into table 'Members'
INSERT INTO Members
( -- columns to insert data into
 [FirstName], [LastName], [PhoneNumber], [JoinDate]
)
VALUES
( -- first row: values for the columns in the list above
 'Raymond', 'Matovu', '256778686569', GETDATE()
),
( -- second row: values for the columns in the list above
 'Daniel', 'Bakaki', '256782318566', GETDATE()
),
( -- second row: values for the columns in the list above
 'Richard', 'Mulema', '256782375559', GETDATE()
),
( -- second row: values for the columns in the list above
 'Kenneth', 'Kisambira', '256772567963', GETDATE()
),
( -- second row: values for the columns in the list above
 'Richard', 'Adrole', '256782339891', GETDATE()
)
-- add more rows here
GO
