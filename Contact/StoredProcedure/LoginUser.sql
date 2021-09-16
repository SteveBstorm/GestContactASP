CREATE PROCEDURE [dbo].[LoginUser]
	@Email VARCHAR(100),
	@Password VARCHAR(50)
AS
	BEGIN
		DECLARE @Salt VARCHAR(100);
		SET @Salt = (SELECT Salt FROM Users WHERE Email = @Email)

		DECLARE @password_hash VARBINARY(64);
		SET @password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password))

		SELECT ScreenName, Email, Id FROM Users 
		WHERE Email LIKE @Email AND [Password] LIKE @password_hash
	END
