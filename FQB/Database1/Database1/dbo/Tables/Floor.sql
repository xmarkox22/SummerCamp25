CREATE TABLE [dbo].[Floor] (
    [Id]          VARCHAR (36) NOT NULL,
    [BuildingId]  VARCHAR (36) NOT NULL,
    [FloorNumber] INT          NOT NULL,
    [HasLift]     BIT          DEFAULT ((1)) NOT NULL,
    [CreatedAt]   DATETIME     DEFAULT (getdate()) NOT NULL,
    [UpdatedAt]   DATETIME     DEFAULT (getdate()) NOT NULL,
    [Code]        VARCHAR (36) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FloorFloorNumber] CHECK ([FloorNumber]>=(-12)),
    CONSTRAINT [FloorHasLift] CHECK ([HasLift]=(1) OR [HasLift]=(0)),
    CONSTRAINT [FKFloor82292] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Building] ([Id]) ON DELETE CASCADE
);

