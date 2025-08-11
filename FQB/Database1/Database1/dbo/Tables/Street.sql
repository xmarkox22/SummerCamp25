CREATE TABLE [dbo].[Street] (
    [Id]        VARCHAR (36)  NOT NULL,
    [Code]      VARCHAR (24)  NOT NULL,
    [Name]      VARCHAR (255) NOT NULL,
    [CreatedAt] DATETIME      DEFAULT (getdate()) NOT NULL,
    [UpdatedAt] DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [Street_Code]
    ON [dbo].[Street]([Code] ASC);


GO
CREATE TRIGGER TrgStreetUpdateUpdatedAt
ON Street
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t
    SET UpdatedAt = GETDATE()
    FROM Street t
    INNER JOIN inserted i ON t.Id = i.Id;
END
