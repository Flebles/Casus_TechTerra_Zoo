CREATE TABLE DierVoeding
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DierId INT NOT NULL,
    GevoerdOp DATETIME NOT NULL,

    CONSTRAINT FK_DierVoeding_Dier
        FOREIGN KEY (DierId) REFERENCES Dier(Id)
);

SELECT * FROM DierVoeding;