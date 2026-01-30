IF NOT EXISTS (
    SELECT * 
    FROM sys.objects 
    WHERE object_id = OBJECT_ID(N'[dbo].[Dier]')
      AND type = N'U'
)
BEGIN
    CREATE TABLE Dier
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Naam NVARCHAR(100) NOT NULL,
        Soort NVARCHAR(100) NOT NULL,
        Geboortedatum DATE NULL,
        Opmerking NVARCHAR(250) NULL,
    )
END

IF NOT EXISTS (
    SELECT * 
    FROM sys.objects 
    WHERE object_id = OBJECT_ID(N'[dbo].[Verblijf]')
    AND type = N'U'
)
BEGIN
    CREATE TABLE Verblijf
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        verblijfNaam NVARCHAR(100) NOT NULL,
        Capaciteit INT NOT NULL,
        Type NVARCHAR(100) NOT NULL,
        Temperatuur INT NOT NULL
    )
END

IF NOT EXISTS (
    SELECT * 
    FROM sys.objects 
    WHERE object_id = OBJECT_ID(N'[dbo].[VoedingSchema]')
    AND type = N'U'
)
BEGIN
    CREATE TABLE VoedingSchema
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Tijd NVARCHAR(50) NOT NULL,
        Voeding NVARCHAR(100) NOT NULL,
        Hoeveelheid NVARCHAR(50) NOT NULL,
        Uitzonderingen NVARCHAR(255) NULL
    )
END

IF NOT EXISTS (
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'[dbo].[DierVoeding]')
    AND type = N'U'
)
BEGIN
    CREATE TABLE DierVoeding
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        DierId INT NOT NULL,
        GevoerdOp DATETIME NOT NULL,

        CONSTRAINT FK_DierVoeding_Dier
            FOREIGN KEY (DierId) REFERENCES Dier(Id)
    )
END

IF NOT EXISTS (
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'[dbo].[VerblijfDier]')
    AND type = N'U'
)
BEGIN
CREATE TABLE VerblijfDier
    (
        VerblijfId INT NOT NULL,
        DierId INT NOT NULL,
        PRIMARY KEY (VerblijfId, DierId),
        FOREIGN KEY (VerblijfId) REFERENCES Verblijf(Id),
        FOREIGN KEY (DierId) REFERENCES Dier(Id)
    )
END