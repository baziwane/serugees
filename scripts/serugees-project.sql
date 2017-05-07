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
    MemberId INT PRIMARY KEY CLUSTERED IDENTITY(1, 1) NOT NULL, -- primary key column
    FirstName [NVARCHAR](50) NOT NULL,
    LastName [NVARCHAR](50) NOT NULL,
    PhoneNumber [NVARCHAR](50) NOT NULL,
    LoginName [NVARCHAR](50) NOT NULL,
    IsActive BIT NULL,
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
    LoanId INT PRIMARY KEY CLUSTERED IDENTITY(1, 1) NOT NULL, -- primary key column
    Amount INT NOT NULL,
    DurationInMonths INT NOT NULL,
    DateRequested DATETIME NOT NULL DEFAULT GETDATE(),
    IsActive BIT NULL,
    MemberId INT FOREIGN KEY REFERENCES Members (MemberId)       
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
    PaymentId INT PRIMARY KEY CLUSTERED IDENTITY(1, 1) NOT NULL, -- primary key column
    LoanPrincipal INT NOT NULL,
    AmountPaid INT NOT NULL,
    DepositDate DATETIME DEFAULT GETDATE(),
    NextInstallmentDueDate DATETIME DEFAULT (GETDATE()+30),
    MinimumPaymentDue INT NOT NULL,
    LoanId INT FOREIGN KEY REFERENCES Loans (LoanId),
);
GO

-- Insert rows into table 'Members'
INSERT INTO Members
( -- columns to insert data into
 [FirstName], [LastName], [PhoneNumber], [JoinDate], [LoginName]
)
VALUES
( -- first row: values for the columns in the list above
 'Raymond', 'Matovu', '256778686569', GETDATE(), 'matovu'
),
( -- second row: values for the columns in the list above
 'Daniel', 'Bakaki', '256782318566', GETDATE(), 'bakaki'
),
( -- second row: values for the columns in the list above
 'Richard', 'Mulema', '256782375559', GETDATE(), 'mulema'
),
( -- second row: values for the columns in the list above
 'Kenneth', 'Kisambira', '256772567963', GETDATE(), 'kisambira'
),
( -- second row: values for the columns in the list above
 'Richard', 'Adrole', '256782339891', GETDATE(), 'adrole'
),
( -- second row: values for the columns in the list above
 'David', 'Batanda', '25677212460', GETDATE(), 'batanda'
),
( -- second row: values for the columns in the list above
 'Kenneth', 'Babigumira', '447844918230', GETDATE(), 'babzi'
)
-- add more rows here
GO

/*
ALTER TABLE dbo.Loans DROP CONSTRAINT FK__Loans__MembersId__3A81B327;
ALTER TABLE dbo.Loans DROP COLUMN MembersId;

ALTER TABLE dbo.Members DROP CONSTRAINT PK__Members__5457C0ABA459DB69;
ALTER TABLE dbo.Members DROP COLUMN MembersId;

ALTER TABLE dbo.Members ADD MembersId int IDENTITY(1, 1) NOT NULL;
ALTER TABLE dbo.Members ADD CONSTRAINT PK_Members PRIMARY KEY CLUSTERED (MemberId);
ALTER TABLE dbo.Loans ADD MembersId INT FOREIGN KEY REFERENCES Members (MembersId)
GO
ALTER TABLE dbo.Members ADD CONSTRAINT PK_Members PRIMARY KEY CLUSTERED (MemberId);
ALTER TABLE dbo.Loans ADD CONSTRAINT PK_Loans PRIMARY KEY CLUSTERED (LoanId);
ALTER TABLE dbo.Payments ADD CONSTRAINT PK_Payments PRIMARY KEY CLUSTERED (PaymentId);
*/