CREATE TABLE [dbo].[District] (
    [Id]            VARCHAR (36)  NOT NULL,
    [Name]          VARCHAR (255) NOT NULL,
    [Zipcode]       VARCHAR (255) NOT NULL,
    [Country]       VARCHAR (255) NOT NULL,
    [City]          VARCHAR (255) NOT NULL,
    [BuildingCount] INT           DEFAULT ((0)) NOT NULL,
    [CreatedAt]     DATETIME      DEFAULT (getdate()) NOT NULL,
    [UpdatedAt]     DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [DistrictBuildingCount] CHECK ([BuildingCount]>=(0)),
    UNIQUE NONCLUSTERED ([Name] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [District_Zipcode]
    ON [dbo].[District]([Zipcode] ASC);


GO
CREATE TRIGGER TrgDistrictUpdateUpdatedAt
ON District
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE d
    SET d.UpdatedAt = GETDATE()
    FROM District d
    INNER JOIN inserted i ON d.Id = i.Id;
END
