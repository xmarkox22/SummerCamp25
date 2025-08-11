CREATE TABLE [dbo].[BuildingCompany] (
    [Id]        VARCHAR (36)   NOT NULL,
    [Name]      VARCHAR (255)  NOT NULL,
    [Cif]       VARCHAR (9)    NOT NULL,
    [Website]   VARCHAR (1024) NULL,
    [CreatedAt] DATETIME       DEFAULT (getdate()) NOT NULL,
    [UpdatedAt] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [BuildingCompanyCif] CHECK (len([Cif])=(9)),
    UNIQUE NONCLUSTERED ([Name] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [BuildingCompany_Cif]
    ON [dbo].[BuildingCompany]([Cif] ASC);


GO
CREATE TRIGGER TrgBuildingCompanyUpdateUpdatedAt
ON BuildingCompany
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t
    SET UpdatedAt = GETDATE()
    FROM BuildingCompany t
    INNER JOIN inserted i ON t.Id = i.Id;
END
