CREATE TABLE [dbo].[Status] (
    [Id]          VARCHAR (36) NOT NULL,
    [Name]        VARCHAR (48) NOT NULL,
    [Description] TEXT         NULL,
    [CreatedAt]   DATETIME     DEFAULT (getdate()) NOT NULL,
    [UpdatedAt]   DATETIME     DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
);


GO
CREATE TRIGGER TrgStatusUpdateUpdatedAt
ON Status
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t
    SET UpdatedAt = GETDATE()
    FROM Status t
    INNER JOIN inserted i ON t.Id = i.Id;
END
