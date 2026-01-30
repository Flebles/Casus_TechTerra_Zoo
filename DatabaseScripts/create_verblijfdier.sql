CREATE TABLE VerblijfDier
(
    VerblijfId INT NOT NULL,
    DierId INT NOT NULL,
    PRIMARY KEY (VerblijfId, DierId),
    FOREIGN KEY (VerblijfId) REFERENCES Verblijf(Id),
    FOREIGN KEY (DierId) REFERENCES Dier(Id)
);

SELECT * FROM VerblijfDier;