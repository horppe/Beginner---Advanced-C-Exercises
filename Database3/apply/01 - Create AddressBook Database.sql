USE Master;
IF NOT EXISTS (SELECT 1 FROM sys.databases where [name] = 'AddressBook')
BEGIN

CREATE DATABASE AddressBook
ON PRIMARY
(
NAME = 'AddressBook',
FILENAME = 'C:\temp\sqlbasics\AddressBook.mdf',
SIZE = 10MB,
MAXSIZE = UNLIMITED,
FILEGROWTH = 50%
)
LOG ON
(
NAME = 'AddressBook_Log',
FILENAME = 'C:\temp\sqlbasics\AddressBook_Log.ldf',
SIZE = 2MB,
MAXSIZE = 100MB,
FILEGROWTH = 2MB
);

END
ELSE
BEGIN

CREATE DATABASE TestingOut
ON PRIMARY
(
NAME = 'TestingOut',
FILENAME = 'C:\temp\sqlbasics\TestingOut.mdf',
SIZE = 20MB,
MAXSIZE = UNLIMITED,
FILEGROWTH = 50%
)
LOG ON
(
NAME = 'TestingOut_Log',
FILENAME = 'C:\temp\sqlbasics\TestingOut.ldf',
SIZE = 2MB,
MAXSIZE = 100MB,
FILEGROWTH = 2MB
);

END

GO