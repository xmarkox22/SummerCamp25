CREATE TABLE [dbo].[Apartment] (
    [Id]        VARCHAR (36) NOT NULL,
    [FloorId]   VARCHAR (36) NOT NULL,
    [Code]      VARCHAR (50) NOT NULL,
    [Door]      VARCHAR (24) NOT NULL,
    [CreatedAt] DATETIME     DEFAULT (getdate()) NOT NULL,
    [UpdatedAt] DATETIME     DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FKApartment152603] FOREIGN KEY ([FloorId]) REFERENCES [dbo].[Floor] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [Apartment_Code]
    ON [dbo].[Apartment]([Code] ASC);


GO
CREATE TRIGGER TrgApartmentUpdateUpdatedAt
ON Apartment
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t
    SET UpdatedAt = GETDATE()
    FROM Apartment t
    INNER JOIN inserted i ON t.Id = i.Id;
END
