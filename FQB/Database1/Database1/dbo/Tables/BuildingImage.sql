CREATE TABLE [dbo].[BuildingImage] (
    [BuildingImageId] VARCHAR (36)   NOT NULL,
    [BuildingId]      VARCHAR (36)   NOT NULL,
    [FileName]        VARCHAR (255)  NOT NULL,
    [FilePath]        VARCHAR (1024) NOT NULL,
    [AltText]         VARCHAR (255)  NULL,
    [IsCoverImage]    BIT            DEFAULT ((0)) NOT NULL,
    [CreatedAt]       DATETIME       DEFAULT (getdate()) NOT NULL,
    [UpdatedAt]       DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([BuildingImageId] ASC),
    CONSTRAINT [FKBuildingIm593721] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Building] ([Id]) ON DELETE CASCADE,
    UNIQUE NONCLUSTERED ([FileName] ASC),
    UNIQUE NONCLUSTERED ([FilePath] ASC)
);


GO
CREATE TRIGGER TrgBuildingImageUpdateUpdatedAt
ON BuildingImage
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t
    SET UpdatedAt = GETDATE()
    FROM BuildingImage t
    INNER JOIN inserted i ON t.BuildingImageId = i.BuildingImageId;
END
