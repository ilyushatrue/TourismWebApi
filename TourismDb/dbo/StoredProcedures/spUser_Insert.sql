CREATE PROCEDURE [dbo].[spUser_Insert]
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email VARCHAR(100),
    @Password VARCHAR(200),
    @PhoneNumber CHAR(11),
    @CreatedDate TIMESTAMP,
    @UpdatedDate TIMESTAMP,
    @IsDeleted BIT 
AS
begin
	insert into dbo.[User] ([FirstName], [LastName], [Email], [Password], [PhoneNumber], [CreatedDate], [UpdatedDate], [IsDeleted])
	values (@FirstName, @LastName, @Email, @Password, @PhoneNumber, @CreatedDate, @UpdatedDate, @IsDeleted);
end

