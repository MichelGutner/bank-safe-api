IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'BankSafeDB')
BEGIN
    CREATE DATABASE BankSafeDB;
END
GO

USE BankSafeDB;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        UserId INT PRIMARY KEY IDENTITY(1, 1),
        Username NVARCHAR(50) NOT NULL,
        Password NVARCHAR(255) NOT NULL,
        Email VARCHAR(50) NOT NULL UNIQUE,
        CPF NVARCHAR(14) NOT NULL UNIQUE,
        CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        UpdatedAt DATETIME2 NULL
    );
END
GO

IF NOT EXISTS(SELECT * FROM sys.tables WHERE name = 'Accounts')
BEGIN
    CREATE TABLE Accounts (
        AccountId INT PRIMARY KEY IDENTITY(1, 1),
        UserId INT NULL,
        AccountNumber VARCHAR(20) UNIQUE NOT NULL,
        Agency NVARCHAR(10) DEFAULT '0001',
        AccountType VARCHAR(20) NOT NULL,
        Balance DECIMAL(19, 4) DEFAULT 0.00,
        CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        Status VARCHAR(20) DEFAULT 'active',
        FOREIGN KEY (UserId) REFERENCES Users(UserId)
    );
END
GO

IF NOT EXISTS(SELECT * FROM sys.tables WHERE name = 'Transactions')
BEGIN
    CREATE TABLE TRANSACTIONS (
        TransactionId INT PRIMARY KEY IDENTITY(1, 1),
        AccountId INT,
        TransactionType VARCHAR(50) NOT NULL,
        Amount DECIMAL(19, 4) NOT NULL,
        CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        Description VARCHAR(255),
        FOREIGN KEY (AccountId) REFERENCES Accounts(AccountId)
    )
END
GO