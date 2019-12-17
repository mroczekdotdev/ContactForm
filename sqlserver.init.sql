IF db_id(N'ContactForm') IS NULL
    CREATE DATABASE ContactForm;
GO

USE ContactForm;
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Forms' and xtype='U')
    CREATE TABLE Forms (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NULL,
    Email VARCHAR(50) NOT NULL,
    Phone VARCHAR(20) NULL,
    Subject NVARCHAR(100) NOT NULL,
    Message NVARCHAR(MAX) NOT NULL
    )
GO

CREATE PROCEDURE AddForm
(
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50) = NULL,
    @Email VARCHAR(50),
    @Phone VARCHAR(20) = NULL,
    @Subject NVARCHAR(100),
    @Message NVARCHAR(MAX)
)
AS
BEGIN
    INSERT INTO Forms (
        FirstName,
        LastName,
        Email,
        Phone,
        Subject,
        Message
        )
    VALUES (
        @FirstName,
        @LastName,
        @Email,
        @Phone,
        @Subject,
        @Message
        )
END
GO
