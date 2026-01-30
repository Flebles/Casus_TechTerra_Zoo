CREATE TABLE VoedingSchema
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Tijd NVARCHAR(50) NOT NULL,
    Voeding NVARCHAR(100) NOT NULL,
    Hoeveelheid NVARCHAR(50) NOT NULL,
    Uitzonderingen NVARCHAR(255) NULL
);

SELECT * FROM VoedingSchema;