CREATE TABLE [dbo].[Building] (
    [Id]                VARCHAR (36)    NOT NULL,
    [DistrictId]        VARCHAR (36)    NOT NULL,
    [StreetId]          VARCHAR (36)    NOT NULL,
    [BuildingCompanyId] VARCHAR (36)    NOT NULL,
    [Name]              VARCHAR (255)   NULL,
    [Description]       TEXT            NULL,
    [Code]              VARCHAR (30)    NOT NULL,
    [Doorway]           VARCHAR (6)     NOT NULL,
    [FloorCount]        INT             DEFAULT ((0)) NOT NULL,
    [YearBuilt]         INT             DEFAULT ((1970)) NOT NULL,
    [Price]             DECIMAL (12, 2) DEFAULT ((0.00)) NOT NULL,
    [EnergyCertificate] CHAR (1)        NULL,
    [CreatedAt]         DATETIME        DEFAULT (getdate()) NOT NULL,
    [UpdatedAt]         DATETIME        DEFAULT (getdate()) NOT NULL,
    [StatusId]          VARCHAR (36)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [BuildingEnergyCertificate] CHECK ([EnergyCertificate]='G' OR [EnergyCertificate]='F' OR [EnergyCertificate]='E' OR [EnergyCertificate]='D' OR [EnergyCertificate]='C' OR [EnergyCertificate]='B' OR [EnergyCertificate]='A'),
    CONSTRAINT [BuildingFloorCount] CHECK ([FloorCount]>=(0)),
    CONSTRAINT [BuildingPrice] CHECK ([Price]>=(0)),
    CONSTRAINT [BuildingYearBuilt] CHECK ([YearBuilt]>=(1800) AND [YearBuilt]<=datepart(year,getdate())),
    CONSTRAINT [FKBuilding279633] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status] ([Id]),
    CONSTRAINT [FKBuilding420566] FOREIGN KEY ([StreetId]) REFERENCES [dbo].[Street] ([Id]),
    CONSTRAINT [FKBuilding524337] FOREIGN KEY ([BuildingCompanyId]) REFERENCES [dbo].[BuildingCompany] ([Id]),
    CONSTRAINT [FKBuilding875021] FOREIGN KEY ([DistrictId]) REFERENCES [dbo].[District] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [Building_Code]
    ON [dbo].[Building]([Code] ASC);


GO
CREATE NONCLUSTERED INDEX [Building_Doorway]
    ON [dbo].[Building]([Doorway] ASC);


GO
CREATE TRIGGER TrgBuildingUpdateUpdatedAt
ON Building
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t
    SET UpdatedAt = GETDATE()
    FROM Building t
    INNER JOIN inserted i ON t.Id = i.Id;
END

GO
CREATE TRIGGER TrgBuildingStatusLogInsert
ON Building
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO BuildingStatusLog (BuildingId, StatusId, CreatedAt)
    SELECT 
        i.Id,
        i.StatusId,
        GETDATE()
    FROM inserted i
    JOIN deleted d ON i.Id = d.Id
    WHERE i.StatusId IS NOT NULL
      AND i.StatusId <> d.StatusId
      AND NOT EXISTS (
        SELECT 1 
        FROM BuildingStatusLog bsl
        WHERE bsl.BuildingId = i.Id
          AND bsl.StatusId = i.StatusId
          AND bsl.CreatedAt = (
              SELECT MAX(CreatedAt)
              FROM BuildingStatusLog
              WHERE BuildingId = i.Id
          )
      );
END
