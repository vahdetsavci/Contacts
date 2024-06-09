CREATE DATABASE ContactsDB

USE ContactsDB
GO

CREATE TABLE Users
(
	ID UNIQUEIDENTIFIER PRIMARY KEY
	, Username VARCHAR(50) UNIQUE
	, Password NVARCHAR(50)
)
GO

INSERT INTO Users VALUES (NEWID(), 'admin1', '1')

CREATE TABLE ContactList
(
	ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID()
	, FirstName	 NVARCHAR(50) NOT NULL
	, LastName 	 NVARCHAR(50) NOT NULL
	, PhoneI	 VARCHAR(20) NOT NULL
	, PhoneII 	 VARCHAR(20)
	, PhoneIII 	 VARCHAR(20)
	, EmailAddress VARCHAR(200)
	, WebAddress 	 VARCHAR(255)
	, Address 	 NVARCHAR(250)
	, Description  NVARCHAR(250)
)
GO

CREATE PROC CheckUser
(
	@username VARCHAR(100)
	, @password NVARCHAR(100)
)
AS
BEGIN
	SELECT COUNT(*) FROM Users
	WHERE Username = @username
		AND Password = @password
END

INSERT INTO Users VALUES (NEWID(), 'admin1', '1')
--EXEC CheckUser 'admin1', '1'

GO
CREATE PROC InsertContact
(
	  @FirstName	NVARCHAR(50)
	, @LastName 	NVARCHAR(50)
	, @PhoneI		VARCHAR(20)
	, @PhoneII 		VARCHAR(20)
	, @PhoneIII 	VARCHAR(20)
	, @EmailAddress	VARCHAR(200) 
	, @WebAddress 	VARCHAR(255)
	, @Address 		NVARCHAR(250)
	, @Description  NVARCHAR(250)
)
AS
BEGIN
	INSERT INTO ContactList(FirstName, LastName, PhoneI, PhoneII, PhoneIII, EmailAddress, WebAddress, Address, Description)
			VALUES (@FirstName, @LastName, @PhoneI, @PhoneII, @PhoneIII, @EmailAddress, @WebAddress, @Address, @Description)
END

GO
CREATE PROC UpdateContact
(
	@ID UNIQUEIDENTIFIER
	, @FirstName	 NVARCHAR(50)
	, @LastName 	 NVARCHAR(50)
	, @PhoneI		VARCHAR(20)
	, @PhoneII 		VARCHAR(20)
	, @PhoneIII 	 VARCHAR(20)
	, @EmailAddress		VARCHAR(200) 
	, @WebAddress 	 VARCHAR(255)
	, @Address 		NVARCHAR(250)
	, @Description  NVARCHAR(250)
)
AS
BEGIN
	UPDATE ContactList
		SET FirstName	= @FirstName	
			, LastName 	= @LastName 	
			, PhoneI	= @PhoneI		
			, PhoneII 	= @PhoneII 		
			, PhoneIII 	= @PhoneIII 	
			, EmailAddress = @EmailAddress
			, WebAddress  = @WebAddress 
			, Address 	= @Address 		
			, Description = @Description
		WHERE ID = @ID
END
GO

CREATE PROC DeleteContact
(
	@ID UNIQUEIDENTIFIER
)
AS
BEGIN
	DELETE FROM ContactList WHERE ID = @ID
END

GO
CREATE PROC ListContacts
AS
SELECT * FROM ContactList

EXEC ListContacts


