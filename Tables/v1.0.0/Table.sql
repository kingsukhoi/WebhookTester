CREATE DATABASE APITester
GO

USE [APITester]
GO
CREATE LOGIN [APITester] WITH PASSWORD=N/*password here*/, DEFAULT_DATABASE=[APITester], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
USE [APITester]
GO
CREATE USER [APITester] FOR LOGIN [APITester]
GO
USE [APITester]
GO
ALTER ROLE [db_owner] ADD MEMBER [APITester]
GO


CREATE TABLE APITester.dbo.Requests
(
    ID           INT IDENTITY
        CONSTRAINT Requests_pk
            PRIMARY KEY NONCLUSTERED,
    Headers      NVARCHAR(MAX),
    Verb         NVARCHAR(MAX),
    Body         NVARCHAR(MAX),
    DateReceived DATETIME DEFAULT getdate()
)
GO
