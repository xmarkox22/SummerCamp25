CREATE TABLE [dbo].[Purchase] (
    [Id]                VARCHAR (36)    NOT NULL,
    [BuildingId]        VARCHAR (36)    NOT NULL,
    [BuildingCompanyId] VARCHAR (36)    NOT NULL,
    [RequestId]         VARCHAR (36)    NOT NULL,
    [Date]              DATETIME        NOT NULL,
    [Amount]            DECIMAL (12, 2) DEFAULT ((0.00)) NOT NULL,
    [CreatedAt]         DATETIME        DEFAULT (getdate()) NOT NULL,
    [UpdatedAt]         DATETIME        DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [PurchaseAmount] CHECK ([Amount]>=(0)),
    CONSTRAINT [FKPurchase526429] FOREIGN KEY ([BuildingCompanyId]) REFERENCES [dbo].[BuildingCompany] ([Id]),
    CONSTRAINT [FKPurchase717750] FOREIGN KEY ([RequestId]) REFERENCES [dbo].[Request] ([Id]),
    CONSTRAINT [FKPurchase78453] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Building] ([Id])
);


GO
CREATE TRIGGER TrgPurchaseUpdateUpdatedAt
ON Purchase
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t
    SET UpdatedAt = GETDATE()
    FROM Purchase t
    INNER JOIN inserted i ON t.Id = i.Id;
END
