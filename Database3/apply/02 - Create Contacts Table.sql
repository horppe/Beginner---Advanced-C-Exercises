USE AddressBook;
IF EXISTS (SELECT 1 FROM sys.tables WHERE [NAME] = 'Contacts')
BEGIN
DROP TABLE dbo.Contacts;
END;
GO

CREATE TABLE dbo.Contacts ( 
ContactId INT,
FirstName VARCHAR(40),
LastName VARCHAR(40),
DateOfBirth DATE, 
PhoneNumbers VARCHAR(200), 
AllowContactByPhone BIT, 
FirstAddress VARCHAR(200), 
SecondAddress VARCHAR(200), 
RoleId INT, 
RoleTitle VARCHAR(200), 
Notes1 VARCHAR(200), 
Notes2 VARCHAR(200),
DrivingLicenseNumber VARCHAR(40), 
PassportNumber VARCHAR(40), 
ContactVerified BIT, 
CreatedDate DATETIME
);
GO