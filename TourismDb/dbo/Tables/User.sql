CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NULL,
    [Email] VARCHAR(100) NULL,
    [Password] VARCHAR(200) NOT NULL,
    [PhoneNumber] CHAR(11) NOT NULL,
    [CreatedDate] TIMESTAMP NOT NULL,
    [UpdatedDate] TIMESTAMP NOT NULL,
    [IsDeleted] BIT NOT NULL,

)
