IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Employees] (
    [EmployeeId] bigint NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [PhoneNumber] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeId])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'FirstName', N'LastName', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Employees]'))
    SET IDENTITY_INSERT [Employees] ON;
INSERT INTO [Employees] ([EmployeeId], [FirstName], [LastName], [PhoneNumber])
VALUES (CAST(1 AS bigint), N'Kavitha', N'Sivalingam', N'9884745335');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'FirstName', N'LastName', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Employees]'))
    SET IDENTITY_INSERT [Employees] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'FirstName', N'LastName', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Employees]'))
    SET IDENTITY_INSERT [Employees] ON;
INSERT INTO [Employees] ([EmployeeId], [FirstName], [LastName], [PhoneNumber])
VALUES (CAST(2 AS bigint), N'Naresh', N'Sivalingam', N'9884857764');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'FirstName', N'LastName', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Employees]'))
    SET IDENTITY_INSERT [Employees] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220616131902_EFCoreCodeFirstSample.Models.EmployeeContext', N'6.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220616132338_EFCoreCodeFirstSample.Models.EmployeeContextSeed', N'6.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Employees] ADD [Gender] nvarchar(max) NOT NULL DEFAULT N'';
GO

UPDATE [Employees] SET [Gender] = N'F'
WHERE [EmployeeId] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Employees] SET [Gender] = N'M'
WHERE [EmployeeId] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220617081637_EFCoreCodeFirstSample.Models.AddEmployeeGender', N'6.0.6');
GO

COMMIT;
GO

