CREATE TABLE Verblijf
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    verblijfNaam NVARCHAR(100) NOT NULL,
    Capaciteit INT NOT NULL,
    Type NVARCHAR(100) NOT NULL,
    Temperatuur INT NOT NULL
);

SELECT * FROM Verblijf;