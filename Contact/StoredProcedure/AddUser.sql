CREATE PROCEDURE [dbo].[AddUser]
	@Email VARCHAR(100),
	@Password VARCHAR(50),
	@ScreenName VARCHAR(50)
AS 
	BEGIN
		DECLARE @Salt VARCHAR(100);
		SET @Salt = NEWID();

		DECLARE @password_hash VARBINARY(64);
		SET @password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password))

		INSERT INTO Users (Email, [Password], ScreenName, Salt)
		VALUES (@Email, @password_hash, @ScreenName, @Salt)
	END