CREATE TABLE [dbo].[Request] (
    [Id]               VARCHAR (36)    NOT NULL,
    [BuildingId]       VARCHAR (36)    NOT NULL,
    [Price]            DECIMAL (12, 2) NOT NULL,
    [MaintenancePrice] REAL            DEFAULT ((0.0)) NOT NULL,
    [CreatedAt]        DATETIME        DEFAULT (getdate()) NOT NULL,
    [UpdatedAt]        DATETIME        DEFAULT (getdate()) NOT NULL,
    [StatusId]         VARCHAR (36)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [RequestMaintenancePrice] CHECK ([MaintenancePrice]>=(0)),
    CONSTRAINT [RequestPrice] CHECK ([Price]>=(0)),
    CONSTRAINT [FKRequest514507] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Building] ([Id]),
    CONSTRAINT [FKRequest898910] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status] ([Id])
);


GO
CREATE TRIGGER TrgRequestUpdateUpdatedAt
ON Request
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t
    SET UpdatedAt = GETDATE()
    FROM Request t
    INNER JOIN inserted i ON t.Id = i.Id;
END

GO
CREATE TRIGGER TrgRequestStatusLogInsert
ON Request
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO RequestStatusLog (RequestId, StatusId, CreatedAt)
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
        FROM RequestStatusLog rsl
        WHERE rsl.RequestId = i.Id
          AND rsl.StatusId = i.StatusId
          AND rsl.CreatedAt = (
              SELECT MAX(CreatedAt)
              FROM RequestStatusLog
              WHERE RequestId = i.Id
          )
      );
END
